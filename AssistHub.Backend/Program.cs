using AssistHub.Backend.HealthChecks;
using AssistHub.Backend.Repositories;
using AssistHub.Backend.Services;
using AssistHub.Backend.Validators.RequestValidators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAssistHubHealthServices();
builder.Services.AddAssistHubServices();
builder.Services.AddAssistHubGuidBasedRepositories();
builder.Services.AddAssistHubRequestValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapAssistHubHealthServices();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();