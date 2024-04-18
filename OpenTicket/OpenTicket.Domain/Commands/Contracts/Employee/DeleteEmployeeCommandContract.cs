using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Commands.Contracts.Employee
{
    public class DeleteEmployeeCommandContract : Contract<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandContract(DeleteEmployeeCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0.");
        }
    }
}
