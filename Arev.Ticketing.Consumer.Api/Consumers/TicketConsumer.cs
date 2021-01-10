using System.Threading.Tasks;
using Arev.Ticketing.Shared.Models.Models;
using MassTransit;

namespace Arev.Ticketing.Consumer.Api.Consumers
{
    public class TicketConsumer : IConsumer<Ticket>
    {
        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
