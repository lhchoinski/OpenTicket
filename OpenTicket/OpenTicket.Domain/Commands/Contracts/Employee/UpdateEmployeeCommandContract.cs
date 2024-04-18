using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Employee;

namespace OpenTicket.Domain.Commands.Contracts.Employee
{
    public class UpdateEmployeeCommandContract : Contract<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandContract(UpdateEmployeeCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0");

            Requires().IsLowerOrEqualsThan(command.Name, 50, "Nome", "O Nome deve conter no máximo 50 caracteres.");
            Requires().IsNotNull(command.Name, "Nome", "Nome é obrigatório");
            if (command.Name != null)
                Requires().AreNotEquals(command.Name.Trim(), string.Empty, "Nome", "Nome não pode ser somente um espaço");

            Requires().IsLowerOrEqualsThan(command.Email, 50, "Email", "O Email deve conter no máximo 50 caracteres.");
            Requires().IsNotNull(command.Email, "Email", "Email é obrigatório");
            if (command.Email != null)
                Requires().AreNotEquals(command.Email.Trim(), string.Empty, "Email", "Email não pode ser somente um espaço");

            Requires().IsNotNull(command.Department, "Department", " O Departamento é obrigatório");
            if (command.Department != null)
            
            Requires().IsNotNull(command.EmployeeType, "EmployeeType", "O Tipo do funcionário é obrigatório");
               
        }
    }
}
