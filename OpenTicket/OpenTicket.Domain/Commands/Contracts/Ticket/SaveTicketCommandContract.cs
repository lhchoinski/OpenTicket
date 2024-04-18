using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Domain.Commands.Contracts.Ticket
{
    public class SaveTicketCommandContract : Contract<SaveTicketCommand>
    {
        public SaveTicketCommandContract(SaveTicketCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0");

            Requires().IsLowerOrEqualsThan(command.Title, 50, "Title", "O Titulo deve conter no máximo 50 caracteres.");
            Requires().IsNotNull(command.Title, "Title", "Titulo é obrigatório");
            if (command.Title != null)
                Requires().AreNotEquals(command.Title.Trim(), string.Empty, "Nome", "Nome não pode ser somente um espaço");

            Requires().IsNotNull(command.Description, "Description", "Descrição é obrigatória");
            if (command.Description != null);
               
        }
    }
}
