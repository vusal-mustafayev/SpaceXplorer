namespace Application.Features.Launches.Queries;

public class GetLaunchesWithPaginationQuery : IRequest<PaginatedList<LaunchDto>>
{
    public string RocketName { get; set; }
    public int Limit { get; set; } = 10;
    public int Offset { get; set; } = 1;
}

internal class GetLaunchesWithPaginationQueryHandler : IRequestHandler<GetLaunchesWithPaginationQuery, PaginatedList<LaunchDto>>
{
    private readonly ISpaceXLaunchService _launchService;

    public GetLaunchesWithPaginationQueryHandler(
        ISpaceXLaunchService launchService)
    {
        _launchService = launchService;
    }

    public async Task<PaginatedList<LaunchDto>> Handle(GetLaunchesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _launchService
            .GetLaunchesAsync(request.Limit, request.Offset, cancellationToken, request.RocketName);
    }
}