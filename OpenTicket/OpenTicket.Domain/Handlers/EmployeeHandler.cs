using OpenTicket.Infra.Comum;
using System.Threading.Tasks;
using OpenTicket.Domain.Enums;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Handlers
{
    public class EmployeeHandler 
    {
        private readonly IEmployeeRepository repository;
        public EmployeeHandler(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICommandResult> SaveEmployeeAsync(SaveEmployeeCommand command)
        {

            var employee = new Employee(
                            command.Name,
                            command.Email,
                            command.Department,
                            command.EmployeeType
                            );

            employee.Id = await repository.SaveAsync(employee);

            return new EmployeeCommandResult(true, "Funcionario inserido com sucesso");
        }
        public async Task<ICommandResult> UpdateEmployeeAsync(UpdateEmployeeCommand command)
        {
            var employee = new Employee(
                            command.Id,
                            command.Name,
                            command.Email,
                            command.Department,
                            command.EmployeeType
                            );

            await repository.UpdateAsync(employee);

            return new EmployeeCommandResult(true,"Funcionario atualizado com sucesso");
        }
        public async Task<ICommandResult> DeleteEmployeeAsync(DeleteEmployeeCommand command)
        {

            await repository.DeleteAsync(command.Id);

            return new EmployeeCommandResult(true, "Funcionario deletado com sucesso");
        }
    }
}
