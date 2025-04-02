using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Mappers;

public static class MapperExtensions
{
    public static void AddAssistHubMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapper<Ticket, TicketGetResponse>, TicketResponseMapper>();
    }
}