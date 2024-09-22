namespace Proconsultation.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public string Celular { get; set; } = string.Empty;
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; } = null!;
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
