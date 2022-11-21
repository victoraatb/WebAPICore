using Core.Models;

namespace MyApp.Repository;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAsync(string filter = null);
    Task<Ticket> GetByIdAsync(int id);
    Task<int> CreateAsync(Ticket ticket);
    Task UpdateAsync(Ticket ticket);
    Task DeleteAsync(int id);
}