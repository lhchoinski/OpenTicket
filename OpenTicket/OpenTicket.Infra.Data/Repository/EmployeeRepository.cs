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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DynamicParameters parameters;
        private readonly DataContext dataContext;
        
        public EmployeeRepository(DataContext context)
        {
            this.dataContext = context;
            this.parameters = new DynamicParameters();
        }

        public async Task<IEnumerable<EmployeeQueryResult>> ListAsync()
        {
            return (await dataContext.Connection.QueryAsync<EmployeeQueryResult>(EmployeeQueries.LISTAR)).ToList();
        }
        
        public async Task<EmployeeQueryResult> GetAsync(int id)
        {
            parameters.Add("@Id", id);
            return await dataContext.Connection.QueryFirstOrDefaultAsync<EmployeeQueryResult>(EmployeeQueries.OBTER, new { id });
        }
        
        public async Task<int> SaveAsync(Employee employee)
        {
            
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Department", employee.Department);
            parameters.Add("@EmployeeType", employee.EmployeeType);

            return await dataContext.Connection.ExecuteAsync(EmployeeQueries.SALVAR, parameters);
        }
        
        public async Task UpdateAsync(Employee employee)
        {
            parameters.Add("@Id", employee.Id);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Department", employee.Department);
            parameters.Add("@EmployeeType", employee.EmployeeType);

            await dataContext.Connection.ExecuteAsync(EmployeeQueries.ATUALIZAR, parameters);
        }
        
        public async Task DeleteAsync(int id)
        {
            parameters.Add("@Id", id);
            await dataContext.Connection.ExecuteAsync(EmployeeQueries.DELETAR, parameters);
        }
    }
}
