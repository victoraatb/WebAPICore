using Core.Models;

namespace MyApp.ApplicationLogic
{
    public interface IProjectsScreenUseCases
    {
        Task<IEnumerable<Project>> ViewProjectsAsync();
    }
}