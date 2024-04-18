using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenTicket.Infra.Comum
{
    public interface ICommandHandler<T> where T : ICommandPadrao
    {
        Task<ICommandResult> HandleAsync(T command);
    }

    public interface ICommandHandlerList<T> where T : ICommandPadrao
    {
        Task<ICommandResult> HandleAsync(List<T> command);
    }
}
