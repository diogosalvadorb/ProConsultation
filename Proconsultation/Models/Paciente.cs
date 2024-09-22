﻿namespace Proconsultation.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
