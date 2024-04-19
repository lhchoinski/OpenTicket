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
    public class TicketRepository : ITicketRepository
    {
        private readonly DynamicParameters parameters;
        private readonly DataContext dataContext;

        public TicketRepository(DataContext context)
        {
            this.dataContext = context;
            this.parameters = new DynamicParameters();
        }

        public async Task<IEnumerable<TicketQueryResult>> ListAsync()
        {
            return (await dataContext.Connection.QueryAsync<TicketQueryResult>(TicketQueries.LISTAR)).ToList();
        }

        public async Task<TicketQueryResult> GetAsync(int id)
        {
            
            parameters.Add("@Id", id);
            return await dataContext.Connection.QueryFirstOrDefaultAsync<TicketQueryResult>(TicketQueries.OBTER, new { id });
        }

        public async Task<int> SaveAsync(Ticket ticket)
        {
            parameters.Add("@Title", ticket.Title);
            parameters.Add("@Description", ticket.Description);
            parameters.Add("@TechnicianDescription", ticket.TechnicianDescription);
            parameters.Add("@CreatedAt", ticket.CreatedAt = DateTime.UtcNow);
            parameters.Add("@UpdatedAt", ticket.UpdatedAt = DateTime.UtcNow);
            parameters.Add("@EmployeeId", ticket.EmployeeId);
            parameters.Add("@AssignedEmployeeId", ticket.AssignedEmployeeId);
            parameters.Add("@Status", ticket.Status = 0);

            return await dataContext.Connection.ExecuteAsync(TicketQueries.SALVAR, parameters);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            parameters.Add("@Id", ticket.Id);
            parameters.Add("@Title", ticket.Title);
            parameters.Add("@Description", ticket.Description);
            parameters.Add("@TechnicianDescription", ticket.TechnicianDescription);
            parameters.Add("@CreatedAt", ticket.CreatedAt);
            parameters.Add("@UpdatedAt", ticket.UpdatedAt = DateTime.UtcNow);
            parameters.Add("@EmployeeId", ticket.EmployeeId);
            parameters.Add("@AssignedEmployeeId", ticket.AssignedEmployeeId);
            parameters.Add("@Status", ticket.Status);

            await dataContext.Connection.ExecuteAsync(TicketQueries.ATUALIZAR, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            parameters.Add("@Id", id);

            await dataContext.Connection.ExecuteAsync(TicketQueries.DELETAR, parameters);
        }
    }
}
