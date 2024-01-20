namespace Application.Features.Launches.Validators;

public class GetLaunchesWithPaginationQueryValidator : AbstractValidator<GetLaunchesWithPaginationQuery>
{
    public GetLaunchesWithPaginationQueryValidator()
    {
        RuleFor(x => x.Offset)
            .GreaterThanOrEqualTo(0).WithMessage("Offset at least greater than or equal to 0.");

        RuleFor(x => x.Limit)
            .GreaterThanOrEqualTo(1).WithMessage("Limit at least greater than or equal to 1.");
    }
}