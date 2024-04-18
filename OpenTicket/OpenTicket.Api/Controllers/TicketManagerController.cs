using OpenTicket.Infra.Comum;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Handlers;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerTicketController : ControllerBase
    {
        private readonly ManagerTicketHandler handler;
        private readonly IManagerTicketRepository repository;

        public ManagerTicketController(ManagerTicketHandler handler, IManagerTicketRepository repository)
        {
            this.handler = handler;
            this.repository = repository;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ICommandResult> UpdateAsync([FromBody] ManagerTicketCommand command)
        {
            return await handler.HandleAsync(command);
        }

       
    }
}
