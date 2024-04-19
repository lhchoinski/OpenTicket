using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Handlers;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Infra.Comum;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketHandler handler;
        private readonly ITicketRepository repository;

        public TicketController(TicketHandler handler, ITicketRepository repository)
        {
            this.handler = handler;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await repository.ListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await repository.GetAsync(id));
        }

        [HttpPost]
        public async Task<ICommandResult> SaveAsync([FromBody] SaveTicketCommand command)
        {
            return await handler.SaveTicketAsync(command);
        }

        [HttpPut]
        public async Task<ICommandResult> UpdateAsync([FromBody] UpdateTicketCommand command)
        {
            return await handler.UpdateTicketAsync(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ICommandResult> DeleteAsync(int id)
        {
            var command = new DeleteTicketCommand() { Id = id };
            return await handler.DeleteAsync(command);
        }
    }
}
