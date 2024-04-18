using System.Threading.Tasks;
using OpenTicket.Domain.Queries;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Domain.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeQueryResult>> ListAsync();
        Task<EmployeeQueryResult> GetAsync(int id);
        Task<int> SaveAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
