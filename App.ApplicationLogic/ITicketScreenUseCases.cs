using Core.Models;

namespace MyApp.ApplicationLogic;

public interface ITicketScreenUseCases
{
    Task<int> AddTicket(Ticket ticket);
    Task DeleteTicket(int ticketId);
    Task UpdateTicket(Ticket ticket);
}