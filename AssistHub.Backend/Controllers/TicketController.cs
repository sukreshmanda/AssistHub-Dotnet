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
        return Ok(ticketService.Create(request));
    }

    [HttpGet("{ticketId:guid}")]
    public IActionResult Get([FromRoute] Guid ticketId)
    {
        return Ok(ticketService.GetById(ticketId));
    }

    [HttpPut("{ticketId:guid}/status")]
    public IActionResult UpdateStatus([FromRoute] Guid ticketId, [FromBody] TicketStatus status)
    {
        ticketService.UpdateStatus(ticketId, status);
        return Ok();
    }

    [HttpDelete("{ticketId:guid}")]
    public IActionResult Delete([FromRoute] Guid ticketId)
    {
        ticketService.Delete(ticketId);
        return Ok();
    }
}