using AssistHub.Backend.Entities;
using FluentValidation;

namespace AssistHub.Backend.Validators.RequestValidators;

public class TicketCreateRequestValidator : AbstractValidator<TicketCreateRequest>
{
    public TicketCreateRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required to create ticket.");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Title must be at least 5 characters.");
        RuleFor(x => x.Title).MaximumLength(50).WithMessage("Title must be less than 50 characters.");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required to create ticket.");
        RuleFor(x => x.Description).MaximumLength(100).WithMessage("Description must be less than 100 characters.");
        RuleFor(x => x.Description).MinimumLength(10).WithMessage("Description must be at least 10 characters.");

        RuleFor(x => x.Priority).NotEmpty().WithMessage("Priority is required to create ticket.");
        RuleFor(x => x.Priority).IsInEnum().WithMessage("Priority must be a valid enum.");
    }
}