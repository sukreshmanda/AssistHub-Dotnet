using AssistHub.Backend.Entities;
using FluentValidation;

namespace AssistHub.Backend.Validators.RequestValidators;

public static class RequestValidatorsExtensions
{
    public static void AddAssistHubRequestValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<TicketCreateRequest>, TicketCreateRequestValidator>();
    }
}