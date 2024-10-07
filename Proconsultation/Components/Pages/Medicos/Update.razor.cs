using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Especialidades;
using Proconsultation.Repositories.Medicos;
using Proconsultation.Extensions;

namespace Proconsultation.Components.Pages.Medicos
{
    public class UpdateMedicoPage : ComponentBase
    {
        [Parameter]
        public int MedicoId { get; set; }

        [Inject]
        public IEspecialidadeRepository EspecialidadeRespository { get; set; } = null!;

        [Inject]
        public IMedicoRespository Respository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        private Medico? CurrentMedico;
        public MedicoInputModel InputModel { get; set; } = new();
        public List<Especialidade> Especialidades { get; set; } = new();
        public DateTime? DataCadastro { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentMedico = await Respository.GetByIdAsync(MedicoId);
            Especialidades = await EspecialidadeRespository.GetAllAsync();

            if (CurrentMedico is null)
                return;

            InputModel = new MedicoInputModel
            {
                Nome = CurrentMedico.Nome,
                Documento = CurrentMedico.Documento,
                Crm = CurrentMedico.Crm,
                Celular = CurrentMedico.Celular,
                EspecialidadeId = CurrentMedico.EspecialidadeId,
            };
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if(CurrentMedico is null) return;

                if (editContext.Model is MedicoInputModel model)
                {
                    CurrentMedico.Id = model.Id;
                    CurrentMedico.Nome = model.Nome;
                    CurrentMedico.Documento = model.Documento.SomenteCaracteres();
                    CurrentMedico.Crm = model.Crm;
                    CurrentMedico.Celular = model.Celular.SomenteCaracteres();
                    CurrentMedico.EspecialidadeId = model.EspecialidadeId;

                    await Respository.UpdateAsync(CurrentMedico);

                    Snackbar.Add("Medico atualizado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
