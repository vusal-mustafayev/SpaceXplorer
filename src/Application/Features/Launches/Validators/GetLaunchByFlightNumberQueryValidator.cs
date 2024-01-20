namespace Application.Features.Launches.Validators;

public class GetLaunchByFlightNumberQueryValidator : AbstractValidator<GetLaunchByFlightNumberQuery>
{
    public GetLaunchByFlightNumberQueryValidator()
    {
        RuleFor(x => x.FlightNumber)
            .NotNull().NotEmpty().GreaterThanOrEqualTo(0).WithMessage("FlightNumber is required.");

        RuleFor(x => x.FlightNumber)
            .GreaterThanOrEqualTo(1).WithMessage("FlightNumber cannot be a minus number.");
    }
}