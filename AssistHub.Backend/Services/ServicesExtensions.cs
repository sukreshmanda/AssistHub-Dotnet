namespace AssistHub.Backend.Services;

public static class ServicesExtensions
{
    public static void AddAssistHubServices(this IServiceCollection services)
    {
        services.AddScoped<TicketService>();
    }
}