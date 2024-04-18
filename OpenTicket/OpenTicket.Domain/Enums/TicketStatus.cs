using System.ComponentModel;

namespace OpenTicket.Domain.Enums
{
    public enum TicketStatus
    {
        [Description("Open")]
        Open = 1,
        [Description("InProgress")]
        InProgress = 2,
        [Description("Resolved")]
        Resolved = 3
    }
}
