using OpenTicket.Infra.Comum;
using System.Threading.Tasks;
using OpenTicket.Domain.Enums;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Domain.Handlers
{
    public class ManagerTicketHandler 
                                        
    {
        private readonly IManagerTicketRepository repository;
        public ManagerTicketHandler(IManagerTicketRepository repository)
        {
            this.repository = repository;
        }

            public async Task<ICommandResult> TicketManagerAsync(ManagerTicketCommand command)
        {

             var ticket = new Ticket(
                            command.Id,
                            command.TechnicianDescription,
                            command.AssignedEmployeeId,
                            command.UpdatedAt = DateTime.UtcNow,
                            command.Status
                            );

            await repository.UpdateAsync(ticket);

            return new ManagerTicketCommandResult(true, "Ticket atualizado com sucesso");
        }
       
    }
}
