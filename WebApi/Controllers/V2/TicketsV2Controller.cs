using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filters;
using WebAPI.Filters.V2;
using WebAPI.QueryFilters;

namespace WebApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/tickets")]
    [Authorize(policy: "WebApiScope")]
    public class TicketsV2Controller : ControllerBase
    {
        private readonly BugsContext db;

        public TicketsV2Controller(BugsContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TicketQueryFilter ticketQueryFilter)
        {
            IQueryable<Ticket> tickets = db.Tickets;
            if (ticketQueryFilter != null)
            {
                tickets = tickets.Where(x => x.TicketId == ticketQueryFilter.Id);
                if (!string.IsNullOrWhiteSpace(ticketQueryFilter.TituloOuDescricao))
                    tickets = tickets.Where(x =>
                        x.Titulo.Contains(ticketQueryFilter.TituloOuDescricao, StringComparison.OrdinalIgnoreCase)
                        || x.Descricao.Contains(ticketQueryFilter.TituloOuDescricao,
                            StringComparison.OrdinalIgnoreCase) || x.Dono.Contains(ticketQueryFilter.TituloOuDescricao, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(await tickets.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ticket = await db.Tickets!.FindAsync(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        [Ticket_GarantirDescricaoPreenchida]
        public async Task<IActionResult> Post([FromBody] Ticket ticket)
        {
            db.Tickets!.Add(ticket);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = ticket.TicketId },
                ticket);
        }


        [HttpPut("{id}")]
        [Ticket_GarantirDescricaoPreenchida]
        public async Task<IActionResult> Put(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
                return BadRequest();

            db.Entry(ticket).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (await db.Tickets!.FindAsync(id) == null)
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await db.Tickets!.FindAsync(id);
            if (ticket == null) return NotFound();

            db.Tickets.Remove(ticket);
            await db.SaveChangesAsync();

            return Ok(ticket);
        }
    }
}