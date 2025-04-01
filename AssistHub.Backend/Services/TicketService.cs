using AssistHub.Backend.Entities;
using AssistHub.Backend.Repositories;

namespace AssistHub.Backend.Services;

public class TicketService(IGuidBasedRepository<Ticket> ticketRepository)
{
    public void Create(TicketCreateRequest request)
    {
        ticketRepository.Add(request.ToTicket());
    }
}