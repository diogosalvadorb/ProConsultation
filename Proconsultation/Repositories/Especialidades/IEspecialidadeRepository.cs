using Proconsultation.Models;

namespace Proconsultation.Repositories.Especialidades
{
    public interface IEspecialidadeRepository
    {
        Task AddAsync(Especialidade especialidade);
        Task UpdateAsync(Especialidade especialidade);
        Task DeleteAsync(int id);
        Task<Especialidade?> GetByIdAsync(int id);
        Task<List<Especialidade>> GetAllAsync();
    }
}
