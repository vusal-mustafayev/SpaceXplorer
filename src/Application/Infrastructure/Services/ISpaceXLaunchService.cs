using System.Threading;

namespace Application.Infrastructure.Services;

public interface ISpaceXLaunchService
{
    Task<LaunchDto> GetLaunchByFlightNumberAsync(int flightNumber, CancellationToken cancellationToken);

    Task<PaginatedList<LaunchDto>> GetLaunchesAsync(int limit, int offset,  CancellationToken cancellationToken,string rocketName = "");
}