using AssistHub.Backend.Entities;
using AssistHub.Backend.Mappers;
using AssistHub.Backend.Repositories;

namespace AssistHub.Backend.Services;

public class TicketService(
    IGuidBasedRepository<Ticket> ticketRepository,
    IMapper<Ticket, TicketGetResponse> ticketResponseMapper)
{
    public Guid Create(TicketCreateRequest request)
    {
        var ticket = request.ToTicket();
        ticketRepository.Add(ticket);
        return ticket.Id;
    }

    public TicketGetResponse GetById(Guid ticketId)
    {
        var ticket = ticketRepository.Get(ticketId);
        return ticketResponseMapper.Map(ticket);
    }

    public void UpdateStatus(Guid ticketId, TicketStatus status)
    {
        var ticket = ticketRepository.Get(ticketId);
        ticket.UpdateStatus(status);
        ticketRepository.Update(ticket);
    }

    public void Delete(Guid ticketId)
    {
        ticketRepository.DeleteById(ticketId);
    }
}