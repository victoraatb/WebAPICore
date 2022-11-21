using App.Repository.ApiClient;
using Core.Models;

namespace MyApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IWebApiExecuter _webApiExecuter;

        public ProjectRepository(IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }

        public async Task<IEnumerable<Project>> GetAsync()
        {
            return await _webApiExecuter.InvokeGet<IEnumerable<Project>>("api/projects");
        }

        public async Task<Project> GetByIDAsync(int id)
        {
            return await _webApiExecuter.InvokeGet<Project>($"api/projects/{id}");
        }

        public async Task<IEnumerable<Ticket>> GetProjectTicketAsync(int projectId, string filter = null)
        {
            string uri = $"api/projects/{projectId}/tickets";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                uri += $"?dono={filter}";
            }
            return await _webApiExecuter.InvokeGet<IEnumerable<Ticket>>(uri);
        }
        
        public async Task<int> CreateAsync(Project project)
        {
            project = await _webApiExecuter.InvokePost("api/projects", project);
            return project.ProjectId;
        }
        
        public async Task UpdateAsync(Project project)
        {
            await _webApiExecuter.InvokePut($"api/projects/{project.ProjectId}", project);
            
        }

        public async Task DeleteAsync(int id)
        {
            await _webApiExecuter.InvokeDelete($"api/projects/{id}");
        }

    }
}