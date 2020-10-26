using Microsoft.EntityFrameworkCore;
using ProjetoPaciente.Model;

namespace ProjetoPaciente.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
             base(options)
            { }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
