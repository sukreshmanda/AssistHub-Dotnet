namespace AssistHub.Backend.Entities;

public class Ticket : GuidBasedEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TicketPriority Priority { get; set; }
    public TicketStatus Status { get; set; }
}

public enum TicketPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}

public enum TicketStatus
{
    Open = 1, //Newly created and awaiting processing
    Closed = 2, //Issue addressed and requester confirmed
    Resolved = 3, //Issue addressed and requester confirmation pending
    AwaitingResponse = 4, //Waiting response from the requester
}