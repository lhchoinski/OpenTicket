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
        private readonly DataContext dataContext;
        
        public EmployeeRepository(DataContext context)
        {
            this.dataContext = context;
        }

        public async Task<IEnumerable<EmployeeQueryResult>> ListAsync()
        {
            return (await dataContext.Connection.QueryAsync<EmployeeQueryResult>(EmployeeQueries.LISTAR)).ToList();
        }
        
        public async Task<EmployeeQueryResult> GetAsync(int id)
        {
            return await dataContext.Connection.QueryFirstOrDefaultAsync<EmployeeQueryResult>(EmployeeQueries.OBTER, new { Id = id });
        }
        
        public async Task<int> SaveAsync(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Department", employee.Department);
            parameters.Add("@EmployeeType", employee.EmployeeType);

            return await dataContext.Connection.ExecuteAsync(EmployeeQueries.SALVAR, parameters);
        }
        
        public async Task UpdateAsync(Employee employee)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", employee.Id);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@Email", employee.Email);
            parameters.Add("@Department", employee.Department);
            parameters.Add("@EmployeeType", employee.EmployeeType);

            await dataContext.Connection.ExecuteAsync(EmployeeQueries.ATUALIZAR, parameters);
        }
        
        public async Task DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            var DataExclusao = DateTime.Now;
            parameters.Add("@Id", id);
            parameters.Add("@DataExclusao", DataExclusao);

            await dataContext.Connection.ExecuteAsync(EmployeeQueries.DELETAR, parameters);
        }
    }
}
