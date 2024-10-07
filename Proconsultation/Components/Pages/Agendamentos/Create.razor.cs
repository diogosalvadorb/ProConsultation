using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Agendamentos;
using Proconsultation.Repositories.Medicos;
using Proconsultation.Repositories.Pacientes;

namespace Proconsultation.Components.Pages.Agendamentos
{
    public class CreateAgendamento : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository AgendamentoRepository { get; set; } = null!;

        [Inject]
        private IMedicoRespository MedicoRepository { get; set; } = null!;

        [Inject]
        private IPacienteRepository PacienteRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;
        protected AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();
        public List<Medico> Medicos { get; set; } = new();
        public List<Paciente> Pacientes { get; set; } = new();

        public DateTime? date { get; set; } = DateTime.Now.Date;
        public TimeSpan? time = new TimeSpan(8, 0, 0);
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;


        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento
                    {
                        Observacao = model.Observacao,
                        PacienteId = model.PacienteId,
                        MedicoId = model.MedicoId,
                        HoraConsulta = time!.Value,
                        DataConsulta = date!.Value
                    };

                    await AgendamentoRepository.AddAsync(agendamento);
                    Snackbar.Add("Agendamento realizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/agendamentos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await MedicoRepository.GetAllAsync();
            Pacientes = await PacienteRepository.GetAllAsync();
        }
    }
}
