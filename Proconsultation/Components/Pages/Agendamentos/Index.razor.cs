using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Agendamentos;

namespace Proconsultation.Components.Pages.Agendamentos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IAgendamentoRepository Repository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public List<Agendamento> Agendamentos { get; set; } = new();

        public async Task DeleteAgendamento(Agendamento agendamento)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                "Atenção"
                , $"Deseja excluir este agendamento {agendamento.Id}?"
                , yesText: "Sim",
                cancelText: "Não"
                );

                if (result is true)
                {
                    await Repository.DeleteAsync(agendamento.Id);
                    Snackbar.Add($"Agendamento {agendamento.Id} excluído, com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Agendamentos = await Repository.GetAllAsync();
        }
    }
}
