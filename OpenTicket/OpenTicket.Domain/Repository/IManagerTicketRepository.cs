using System.Threading.Tasks;
using System.Collections.Generic;
using OpenTicket.Domain.Queries;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Domain.Repository
{
    public interface IManagerTicketRepository
    {
        Task UpdateAsync(Ticket ticket);
       
    }
}
