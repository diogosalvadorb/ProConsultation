using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Pacientes;
using Proconsultation.Extensions;

namespace Proconsultation.Components.Pages.Pacientes
{
    public class UpdatePaciente : ComponentBase
    {
        [Parameter]
        public int PacienteId { get; set; }

        [Inject]
        public IPacienteRepository respository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();

        private Paciente? CurrentPaciente;
        public DateTime? DataNascimento { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentPaciente = await respository.GetByIdAsync(PacienteId);

            if (CurrentPaciente is null)
                return;

            InputModel = new PacienteInputModel
            {
                Id = CurrentPaciente.Id,
                Nome = CurrentPaciente.Nome,
                Email = CurrentPaciente.Email,
                Celular = CurrentPaciente.Celular,
                Documento = CurrentPaciente.Documento,
                DataNascimento = CurrentPaciente.DataNascimento
            };

            DataNascimento = CurrentPaciente.DataNascimento;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    CurrentPaciente.Nome = model.Nome;
                    CurrentPaciente.Documento = model.Documento.SomenteCaracteres();
                    CurrentPaciente.Celular = model.Celular.SomenteCaracteres();
                    CurrentPaciente.Email = model.Email;
                    CurrentPaciente.DataNascimento = DataNascimento.Value;

                    await respository.UpdateAsync(CurrentPaciente);

                    Snackbar.Add("Paciente actualizado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
