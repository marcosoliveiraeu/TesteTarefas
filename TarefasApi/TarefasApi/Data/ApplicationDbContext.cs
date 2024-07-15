using Microsoft.EntityFrameworkCore;
using TarefasApi.Models;

namespace TarefasApi.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
       {     
       }

        public DbSet<StatusTarefa> StatusTarefas { get; set; } = default!;

        public DbSet<Tarefa> Tarefas { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StatusTarefa>().HasData(
                new StatusTarefa { Id = 1, Descricao = "Pendente" },
                new StatusTarefa { Id = 2, Descricao = "Concluída" }
            );
        }


    }
}
