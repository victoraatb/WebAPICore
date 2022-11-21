using Core.Models;
using MyApp.Repository;

namespace MyApp.ApplicationLogic
{
    public class TicketScreenUseCases : ITicketScreenUseCases
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketScreenUseCases(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<int> AddTicket(Ticket ticket)
        {
            return await this._ticketRepository.CreateAsync(ticket);
        }

        public async Task DeleteTicket(int ticketId)
        {
            await this._ticketRepository.DeleteAsync(ticketId);
        }
        
        public async Task UpdateTicket(Ticket ticket)
        {
            await _ticketRepository.UpdateAsync(ticket);
        }
    }
}