﻿using System.ComponentModel.DataAnnotations;

namespace Proconsultation.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "O campo Documento é obrigatório")]
        public string Documento { get; set; } = null!;
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um email válido")]
        [MaxLength(50, ErrorMessage = "O campo Email deve ter no máximo 50 caracteres")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "O campo Celular é obrigatório")]
        public string Celular { get; set; } = null!;
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

    }
}
