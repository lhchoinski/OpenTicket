using System;
using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Queries
{
    public class EmployeeQueryResult
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
