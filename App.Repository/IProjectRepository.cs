using Core.Models;

namespace MyApp.Repository;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAsync();
    Task<Project> GetByIDAsync(int id);
    Task<int> CreateAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(int id);
    Task<IEnumerable<Ticket>> GetProjectTicketAsync(int projectId, string filter = null);
}