using Microsoft.EntityFrameworkCore;
using Proconsultation.Data;
using Proconsultation.Models;

namespace Proconsultation.Repositories.Agendamentos
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _context
                .Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos
                .Include(a => a.Paciente)
                .Include(a => a.Medico)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agendamento = await GetByIdAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AgendamentosAnuais>> GetReportAsync()
        {
            var result = _context.Database.SqlQuery<AgendamentosAnuais>
                ($"SELECT MONTH(DataConsulta) AS Mes, COUNT(*) AS QuantidadeAgendamentos FROM Agendamentos WHERE YEAR(DataConsulta) = {DateTime.Today.Year.ToString()} GROUP BY MONTH(DataConsulta) ORDER BY Mes");

            return await Task.FromResult(result.ToList());
        }
    }
}
