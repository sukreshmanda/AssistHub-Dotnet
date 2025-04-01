using AssistHub.Backend.Entities;
using AssistHub.Backend.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AssistHub.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController(TicketService ticketService, IValidator<TicketCreateRequest> ticketCreateValidator)
    : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] TicketCreateRequest request)
    {
        ticketCreateValidator.ValidateAndThrow(request);
        ticketService.Create(request);
        return Ok();
    }
}