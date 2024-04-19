using System;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Queries
{
    public class TicketQueryResult
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public string? TechnicianDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EmployeeId { get; set; } 
        public int? AssignedEmployeeId { get; set; } 
        public TicketStatus Status { get; set; } 
    }
}
