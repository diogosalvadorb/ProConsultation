using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Pacientes;

namespace Proconsultation.Components.Pages.Pacientes
{
    public class CreatePacientePage : ComponentBase
    {
        [Inject]
        public IPacienteRepository respository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();

        public DateTime? DataNascimento { get; set; } = DateTime.Today;

        public DateTime? MaxDate { get; set; } = DateTime.Today;


        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = new Paciente
                    {
                        Nome = model.Nome,
                        DataNascimento = DataNascimento.Value,
                        Email = model.Email,
                        Celular = model.Celular,
                        Documento = model.Documento,
                    };

                    await respository.AddAsync(paciente);
                    Snackbar.Add("Paciente adicionado com sucesso", Severity.Success);
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
