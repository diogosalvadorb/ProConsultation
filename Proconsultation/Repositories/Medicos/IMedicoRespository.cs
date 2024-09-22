using Proconsultation.Models;

namespace Proconsultation.Repositories.Medicos
{
    public interface IMedicoRespository
    {
        Task AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task DeleteByIdAsync(int id);
        Task<Medico?> GetByIdAsync(int id);
        Task<List<Medico>> GetAllAsync();
    }
}
