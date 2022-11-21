using Core.Models;

namespace MyApp.ApplicationLogic;

public interface ITicketsScreenUseCases
{
    Task<IEnumerable<Ticket>> SearchTickets(string filter);
    Task<IEnumerable<Ticket>> ViewTickets(int projectId);

    Task<IEnumerable<Ticket>> ViewOwnersTickets(int projectID, string ownerName);
    Task<Ticket> ViewTicketById(int ticketId);
}