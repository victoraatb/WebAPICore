using MyApp.Repository;
using Core.Models;

namespace MyApp.ApplicationLogic
{
    public class ProjectsScreenUseCases : IProjectsScreenUseCases
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsScreenUseCases(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> ViewProjectsAsync()
        {
            return await _projectRepository.GetAsync();
        }
    }
}