using System;
using Flunt.Notifications;
using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Contracts.Employee;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Commands.Input.Employee
{
    public class SaveEmployeeCommand : Notifiable<Notification>, ICommandPadrao
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool EhValido()
        {
            AddNotifications(new SaveEmployeeCommandContract(this));
            return IsValid;
        }
    }
}
