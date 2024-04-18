using OpenTicket.Infra.Comum;
using System.Threading.Tasks;
using OpenTicket.Domain.Enums;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Repository;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Handlers
{
    public class EmployeeHandler : ICommandHandler<SaveEmployeeCommand>,
                                        ICommandHandler<UpdateEmployeeCommand>,
                                        ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository repository;
        public EmployeeHandler(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICommandResult> HandleAsync(SaveEmployeeCommand command)
        {
            if (!command.EhValido())
                return new EmployeeCommandResult(false, "Não foi possível salvar o funcionario", command.Notifications);

            var employee = new Employee(

                            command.Name,
                            command.Email,
                            command.Department,
                            command.EmployeeType
                            );

            employee.Id = await repository.SaveAsync(employee);

            return new EmployeeCommandResult(true, "Funcionario inserido com sucesso", command);
        }
        public async Task<ICommandResult> HandleAsync(UpdateEmployeeCommand command)
        {
            if (!command.EhValido())
                return new EmployeeCommandResult(false, "Não foi possível atualizar o funcionario", command.Notifications);

            var employee = new Employee(
                            command.Id,
                            command.Name,
                            command.Email,
                            command.Department,
                            command.EmployeeType
                            );

            await repository.UpdateAsync(employee);

            return new EmployeeCommandResult(true, "Funcionario atualizado com sucesso", command);
        }
        public async Task<ICommandResult> HandleAsync(DeleteEmployeeCommand command)
        {
            if (!command.EhValido())
                return new EmployeeCommandResult(false, "Não foi possível deletar o funcionario", command.Notifications);

            await repository.DeleteAsync(command.Id);

            return new EmployeeCommandResult(true, "Funcionario deletado com sucesso", command);
        }
    }
}
