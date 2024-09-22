using Proconsultation.Models;

namespace Proconsultation.Repositories.Agendamentos
{
    public interface IAgendamentoRepository
    {
        Task AddAsync(Agendamento agendamento);
        Task DeleteAsync(int id);
        Task<Agendamento?> GetByIdAsync(int id);
        Task<List<Agendamento>> GetAllAsync();
    }
}
