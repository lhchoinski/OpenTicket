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
    public class TicketHandler : ICommandHandler<SaveTicketCommand>,
                                        ICommandHandler<UpdateTicketCommand>,
                                        ICommandHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository repository;
        public TicketHandler(ITicketRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICommandResult> HandleAsync(SaveTicketCommand command)
        {
            if (!command.EhValido())
                return new TicketCommandResult(false, "Não foi possível abrir o ticket", command.Notifications);

            var ticket = new Ticket(
                            command.Title,
                            command.Description,
                            command.TechnicianDescription,
                            command.CreatedAt,
                            command.UpdatedAt,
                            command.EmployeeId,
                            command.AssignedEmployeeId,
                            command.Status
                            );

            ticket.Id = await repository.SaveAsync(ticket);

            return new TicketCommandResult(true, "Ticket inserido com sucesso", command);
        }
        public async Task<ICommandResult> HandleAsync(UpdateTicketCommand command)
        {
            if (!command.EhValido())
                return new TicketCommandResult(false, "Não foi possível atualizar o ticket", command.Notifications);

             var ticket = new Ticket(
                            command.Title,
                            command.Description,
                            command.TechnicianDescription,
                            command.CreatedAt,
                            command.UpdatedAt,
                            command.EmployeeId,
                            command.AssignedEmployeeId,
                            command.Status
                            );

            await repository.UpdateAsync(ticket);

            return new TicketCommandResult(true, "Ticket atualizado com sucesso", command);
        }
        public async Task<ICommandResult> HandleAsync(DeleteTicketCommand command)
        {
            if (!command.EhValido())
                return new TicketCommandResult(false, "Não foi possível deletar o Ticket", command.Notifications);

            await repository.DeleteAsync(command.Id);

            return new TicketCommandResult(true, "Ticket deletado com sucesso", command);
        }
    }
}
