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
    public class ManagerTicketHandler : ICommandHandler<ManagerTicketCommand>
                                        
    {
        private readonly IManagerTicketRepository repository;
        public ManagerTicketHandler(IManagerTicketRepository repository)
        {
            this.repository = repository;
        }

            public async Task<ICommandResult> HandleAsync(ManagerTicketCommand command)
        {
            if (!command.EhValido())
                return new ManagerTicketCommandResult(false, "Não foi possível atualizar o ticket", command.Notifications);

             var ticket = new Ticket(
                            command.TechnicianDescription,
                            command.AssignedEmployeeId,
                            command.UpdatedAt,
                            command.Status
                            );

            await repository.UpdateAsync(ticket);

            return new ManagerTicketCommandResult(true, "Ticket atualizado com sucesso", command);
        }
       
    }
}
