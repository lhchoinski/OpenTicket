using System;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Queries
{
    public class ManagerTicketQueryResult
    {
        
        public string? TechnicianDescription { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AssignedEmployeeId { get; set; } 
        public TicketStatus Status { get; set; } 
    }
}
