using System.Threading.Tasks;
using OpenTicket.Domain.Enums;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Infra.Comum;

namespace OpenTicket.Domain.Handlers
{
    public class TicketHandler
    {
        private readonly ITicketRepository repository;
        private readonly IEmployeeRepository employeeRepository;
        public TicketHandler(ITicketRepository repository, IEmployeeRepository employeeRepository)
        {
            this.repository = repository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ICommandResult> SaveTicketAsync(SaveTicketCommand command)
        {

            var ticket = new Ticket(
                            command.Title,
                            command.Description,
                            command.TechnicianDescription,
                            command.CreatedAt = DateTime.UtcNow,
                            command.UpdatedAt = DateTime.UtcNow,
                            command.EmployeeId,
                            command.AssignedEmployeeId,
                            command.Status = 0
                            );

            ticket.Id = await repository.SaveAsync(ticket);

            return new TicketCommandResult(true, "Ticket inserido com sucesso");
        }

        public async Task<ICommandResult> UpdateTicketAsync(UpdateTicketCommand command)
        {

            var ticket = new Ticket(
                           command.Id,
                           command.Title,
                           command.Description,
                           command.TechnicianDescription,
                           command.CreatedAt,
                           command.UpdatedAt = DateTime.UtcNow,
                           command.EmployeeId,
                           command.AssignedEmployeeId,
                           command.Status
                           );

            await repository.UpdateAsync(ticket);


            return new TicketCommandResult(true, "Ticket atualizado com sucesso");
        }
        public async Task<ICommandResult> DeleteAsync(DeleteTicketCommand command)
        {

            await repository.DeleteAsync(command.Id);

            return new TicketCommandResult(true, "Ticket deletado com sucesso");
        }
    }
}