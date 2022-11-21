using MyApp.Repository;
using App.Repository.ApiClient;
using Core.Models;

HttpClient httpClient = new();
IWebApiExecuter webApiExecuter = new WebApiExecuter("https://localhost:44304", new HttpClient(), new TokenRepository());

await GetProjects();
var pID = await CreateProject();
await GetProjectTickets(2);
await GetProjects();

var project = await GetProject(pID);
await UpdateProject(project);
await GetProjects();

await DeleteProject(3);
await GetProjects();

async Task GetProjects()
{
    ProjectRepository repository = new(webApiExecuter);
    var projects = await repository.GetAsync();
    foreach (var project in projects)
    {
        Console.WriteLine($"Projeto: {project.Name}");
    }
}

async Task<Project> GetProject(int id)
{
    ProjectRepository repository = new(webApiExecuter);
    return await repository.GetByIDAsync(id);
}

async Task GetProjectTickets(int id)
{
    var project = await GetProject(id);
    Console.WriteLine($"Projeto: {project.Name}");

    ProjectRepository repository = new(webApiExecuter);
    var tickets = await repository.GetProjectTicketAsync(id, "teste");

    foreach (var ticket in tickets)
    {
        Console.WriteLine($"       Ticket: {ticket.Titulo}");
    }
}

async Task<int> CreateProject()
{
    var project = new Project { Name = "Outro Projeto" };
    ProjectRepository repository = new(webApiExecuter);
    return await repository.CreateAsync(project);
}

async Task UpdateProject(Project project)
{
    ProjectRepository repository = new(webApiExecuter);
    project.Name += " atualizado";
    await repository.UpdateAsync(project);
}

async Task DeleteProject(int id)
{
    ProjectRepository repository = new(webApiExecuter);
    await repository.DeleteAsync(id);
}