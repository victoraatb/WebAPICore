using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataStore.EF
{
    public class BugsContext: DbContext
    {
        public BugsContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Projeto 1"},
                new Project { ProjectId = 2, Name = "Projeto 2"}

            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Titulo = "Bug #1", ProjectId = 1, Dono = "Victor Baptistella", DataOcorrencia = new DateTime(2022, 9, 25), DataVencimento = new DateTime(2022,09,28)},
                new Ticket { TicketId = 2, Titulo = "Bug #2", ProjectId = 2, Dono = "Victor Baptistella", DataOcorrencia = new DateTime(2022, 9, 25), DataVencimento = new DateTime(2022,09,28)},
                new Ticket { TicketId = 3, Titulo = "Bug #3", ProjectId = 1, Dono = "Victor Baptistella", DataOcorrencia = new DateTime(2022, 9, 25), DataVencimento = new DateTime(2022,09,28)}
            );
            
        }
    }
    
}