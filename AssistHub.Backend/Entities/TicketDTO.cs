namespace AssistHub.Backend.Entities;

public class TicketCreateRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TicketPriority Priority { get; set; }

    public Ticket ToTicket()
    {
        return new Ticket()
        {
            Id = Guid.NewGuid(),
            Title = Title,
            Description = Description,
            Status = TicketStatus.Open,
            Priority = TicketPriority.Low,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
    }
}

public class TicketGetResponse
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TicketPriority Priority { get; set; }
    public TicketStatus Status { get; set; }
}