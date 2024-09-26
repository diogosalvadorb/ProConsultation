using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Proconsultation.Models;
using Proconsultation.Repositories.Especialidades;
using Proconsultation.Repositories.Medicos;
using Proconsultation.Extensions;

namespace Proconsultation.Components.Pages.Medicos
{
    public class CreateMedico : ComponentBase
    {
        [Inject]
        private IEspecialidadeRepository EspecialidadeRespository { get; set; } = null!;

        [Inject]
        public IMedicoRespository Respository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
        public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();
        public DateTime? DataCadastro { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        Crm = model.Crm.SomenteCaracteres(),
                        EspecialidadeId = model.EspecialidadeId,
                        DataCadastro = model.DataCadastro,
                    };

                    await Respository.AddAsync(medico);
                    Snackbar.Add("Médico cadastrado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/medicos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Especialidades = await EspecialidadeRespository.GetAllAsync();
        }
    }
}
