using System.Threading.Tasks;
using System.Collections.Generic;
using OpenTicket.Domain.Queries;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Domain.Repository
{
    public interface ITicketRepository
    {
        Task<IEnumerable<TicketQueryResult>> ListAsync();
        Task<TicketQueryResult> GetAsync(int id);
        Task<int> SaveAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
    }
}
