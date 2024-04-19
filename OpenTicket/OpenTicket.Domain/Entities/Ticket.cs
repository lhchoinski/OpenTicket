using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Entities
{
    public class Ticket
    {
        public Ticket(int id, string? technicianDescription, int assignedEmployeeId, DateTime? updatedAt, TicketStatus status)
        {
            Id = id;
            TechnicianDescription = technicianDescription;
            AssignedEmployeeId = assignedEmployeeId;
            UpdatedAt = updatedAt;
            Status = status;
        }

        public Ticket(string title, string description, string? technicianDescription, DateTime createdAt, DateTime? updatedAt, int employeeId, int? assignedEmployeeId, TicketStatus status)
        {
            Title = title;
            Description = description;
            TechnicianDescription = technicianDescription;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            EmployeeId = employeeId;
            AssignedEmployeeId = assignedEmployeeId;
            Status = status;
        }

        public Ticket(int id,string title, string description, string? technicianDescription, DateTime createdAt, DateTime? updatedAt, int employeeId, int? assignedEmployeeId, TicketStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            TechnicianDescription = technicianDescription;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            EmployeeId = employeeId;
            AssignedEmployeeId = assignedEmployeeId;
            Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? TechnicianDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EmployeeId { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public TicketStatus Status { get; set; }


    }
}
