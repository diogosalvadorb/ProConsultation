using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proconsultation.Models;
using System.Reflection;

namespace Proconsultation.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Especialidade> especialidades {  get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<Agendamento> agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            new DbInitializer(builder).Seed();

            base.OnModelCreating(builder);
        }
    }
}
