using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Mappers;

public class TicketResponseMapper : IMapper<Ticket, TicketGetResponse>
{
    public TicketGetResponse Map(Ticket source)
    {
        return new TicketGetResponse()
        {
            Title = source.Title,
            Description = source.Description,
            Priority = source.Priority,
            Status = source.Status,
        };
    }
}