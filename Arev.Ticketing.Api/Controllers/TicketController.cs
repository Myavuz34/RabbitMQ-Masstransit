using System;
using System.Threading.Tasks;
using Arev.Ticketing.Shared.Models.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Arev.Ticketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBus _bus;
        public TicketController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.BookedOn = DateTime.Now;
                Uri uri = new Uri("rabbitmq://myrabbit/ticketQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}