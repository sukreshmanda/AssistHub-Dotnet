using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace AssistHub.Backend.HealthChecks;

public static class HealthServicesExtensions
{
    public static void AddAssistHubHealthServices(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<ApplicationHealth>("Application", tags: ["application"]);
    }

    public static void MapAssistHubHealthServices(this WebApplication app)
    {
        app.MapHealthChecks("/hell-thy", new HealthCheckOptions()
        {
            ResponseWriter = async (context, response) =>
            {
                context.Response.ContentType = "application/json";
                var res = new
                {
                    status = response.Status.ToString(),
                    checks = response.Entries.Select(r => new
                    {
                        name = r.Key,
                        status = r.Value.Status.ToString(),
                        description = r.Value.Description,
                    })
                };

                await context.Response.WriteAsJsonAsync(res);
            }
        });
    }
}