namespace Application.Features.Launches.Queries;

public class GetLaunchByFlightNumberQuery : IRequest<LaunchDto>
{
    public int FlightNumber { get; set; }

    internal class GetLaunchByFlightNumberQueryHandler : IRequestHandler<GetLaunchByFlightNumberQuery, LaunchDto>
    {
        private readonly ISpaceXLaunchService _launchService;
        public GetLaunchByFlightNumberQueryHandler(
            ISpaceXLaunchService launchService)
        {
            _launchService = launchService;
        }

        public async Task<LaunchDto> Handle(GetLaunchByFlightNumberQuery request, CancellationToken cancellationToken)
        {
            var launch = await _launchService
                .GetLaunchByFlightNumberAsync(request.FlightNumber, cancellationToken);

            if (launch == null)
                throw new NotFoundException("Launch", "flight number", request.FlightNumber);

            return launch;
        }
    }
}
