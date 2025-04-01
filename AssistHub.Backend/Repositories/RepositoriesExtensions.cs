using AssistHub.Backend.Entities;

namespace AssistHub.Backend.Repositories;

public static class RepositoriesExtensions
{
    public static void AddAssistHubGuidBasedRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGuidBasedRepository<Ticket>, GuidBasedRepositoryBase<Ticket>>();
    }
}