using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AssistHub.Backend.HealthChecks;

public class ApplicationHealth : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(new HealthCheckResult(HealthStatus.Healthy, description: "Application is healthy"));
    }
}