using System;
using Flunt.Notifications;
using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Contracts.Ticket;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Commands.Input.Ticket
{
    public class SaveTicketCommand : Notifiable<Notification>, ICommandPadrao
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? TechnicianDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EmployeeId { get; set; } 
        public int? AssignedEmployeeId { get; set; } 
        public TicketStatus Status { get; set; }
        public bool EhValido()
        {
            AddNotifications(new SaveTicketCommandContract(this));
            return IsValid;
        }
    }
}
