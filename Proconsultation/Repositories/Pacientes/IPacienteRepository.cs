using Proconsultation.Models;

namespace Proconsultation.Repositories.Pacientes
{
    public interface IPacienteRepository
    {
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task<Paciente?> GetByIdAsync(int id);
        Task<List<Paciente>> GetAllAsync();
        Task DeleteByIdAsync(int id);
    }
}
