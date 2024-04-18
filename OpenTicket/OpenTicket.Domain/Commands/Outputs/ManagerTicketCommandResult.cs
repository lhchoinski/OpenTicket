using OpenTicket.Infra.Comum;

namespace OpenTicket.Domain.Commands.Output
{
    public class ManagerTicketCommandResult : ICommandResult
    {
        public ManagerTicketCommandResult(bool sucess, string message, object data)
        {
            Success = sucess;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
