using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Medicos;

namespace Proconsultation.Components.Pages.Medicos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IMedicoRespository Respository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        public List<Medico> Medicos { get; set; } = new List<Medico>();

        public bool HideButtons { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task DeleteMedicoAsync(Medico medico)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Atenção"
                    , $"Deseja excluir o médico {medico.Nome}?"
                    , yesText: "Sim",
                    cancelText: "Não"
                );

                if (result is true)
                {
                    await Respository.DeleteByIdAsync(medico.Id);
                    Snackbar.Add($"Médico excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/medicos/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Atendente");

            Medicos = await Respository.GetAllAsync();
        }
    }
}
