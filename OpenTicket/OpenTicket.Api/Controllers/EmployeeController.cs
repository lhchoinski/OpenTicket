using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Handlers;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Infra.Comum;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeHandler handler;
        private readonly IEmployeeRepository repository;

        public EmployeeController(EmployeeHandler handler, IEmployeeRepository repository)
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
        public async Task<ICommandResult> SaveAsync([FromBody] SaveEmployeeCommand command)
        {
            return await handler.SaveEmployeeAsync(command);
        }

        [HttpPut]
        public async Task<ICommandResult> UpdateAsync([FromBody] UpdateEmployeeCommand command)
        {
            return await handler.UpdateEmployeeAsync(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ICommandResult> DeleteAsync(int id)
        {
            var command = new DeleteEmployeeCommand() { Id = id };
            return await handler.DeleteEmployeeAsync(command);
        }
    }
}
