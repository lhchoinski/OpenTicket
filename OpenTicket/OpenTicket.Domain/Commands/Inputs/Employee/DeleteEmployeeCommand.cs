using Flunt.Notifications;
using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Contracts.Employee;

namespace OpenTicket.Domain.Commands.Input.Employee
{
    public class DeleteEmployeeCommand : Notifiable<Notification>, ICommandPadrao
    {
        public int Id { get; set; }
        public bool EhValido()
        {
            AddNotifications(new DeleteEmployeeCommandContract(this));
            return IsValid;
        }
    }
}
