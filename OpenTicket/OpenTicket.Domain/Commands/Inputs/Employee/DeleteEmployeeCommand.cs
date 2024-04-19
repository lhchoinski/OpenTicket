using Flunt.Notifications;
using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Contracts.Employee;

namespace OpenTicket.Domain.Commands.Input.Employee
{
    public class DeleteEmployeeCommand 
    {
        public int Id { get; set; }
       
    }
}
