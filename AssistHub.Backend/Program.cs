using AssistHub.Backend.HealthChecks;
using AssistHub.Backend.Mappers;
using AssistHub.Backend.Middlewares;
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
builder.Services.AddAssistHubMappers();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapAssistHubHealthServices();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/openapi/v1.json", "AssistHub API"); });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();