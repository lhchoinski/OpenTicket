using Flunt.Notifications;
using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Contracts.Ticket;

namespace OpenTicket.Domain.Commands.Input.Ticket
{
    public class DeleteTicketCommand : Notifiable<Notification>, ICommandPadrao
    {
        public int Id { get; set; }
        public bool EhValido()
        {
            AddNotifications(new DeleteTicketCommandContract(this));
            return IsValid;
        }
    }
}
