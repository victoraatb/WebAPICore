using Core.Models;
using MyApp.Repository;

namespace MyApp.ApplicationLogic
{
    public class TicketsScreenUseCases : ITicketsScreenUseCases
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITicketRepository _ticketRepository;


        public TicketsScreenUseCases(IProjectRepository projectRepository, ITicketRepository ticketRepository)
        {
            _projectRepository = projectRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> ViewTickets(int projectId)
        {
            return await _projectRepository.GetProjectTicketAsync(projectId);
        }

        public async Task<IEnumerable<Ticket>> SearchTickets(string filter)
        {
            if (int.TryParse(filter, out int ticketId))
            {
                var ticket = await _ticketRepository.GetByIdAsync(ticketId);
                var tickets = new List<Ticket>();
                tickets.Add(ticket);
                return tickets;
            }
            
            return await _ticketRepository.GetAsync(filter);
        }

        public async Task<IEnumerable<Ticket>> ViewOwnersTickets(int projectID, string ownerName)
        {
            return await _projectRepository.GetProjectTicketAsync(projectID, ownerName);
        }

        public async Task<Ticket> ViewTicketById(int ticketId)
        {
            return await _ticketRepository.GetByIdAsync(ticketId);
        }
    }
}