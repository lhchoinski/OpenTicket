using System;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using OpenTicket.Domain.Queries;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Repository;
using OpenTicket.Infra.Data.Context;
using OpenTicket.Infra.Data.Queries;

namespace OpenTicket.Infra.Data.Repository
{
    public class ManagerTicketRepository : IManagerTicketRepository
    {
        private readonly DynamicParameters parameters;
        private readonly DataContext dataContext;
        public ManagerTicketRepository(DataContext context)
        {
            this.dataContext = context;
            this.parameters = new DynamicParameters();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            parameters.Add("@Id",ticket.Id);
            parameters.Add("@TechnicianDescription", ticket.TechnicianDescription);
            parameters.Add("@UpdatedAt", ticket.UpdatedAt = DateTime.UtcNow);
            parameters.Add("@AssignedEmployeeId",ticket.AssignedEmployeeId);
            parameters.Add("@Status", ticket.Status);

            await dataContext.Connection.ExecuteAsync(ManagerTicketQueries.ATUALIZAR, parameters);
        }
    }
}
