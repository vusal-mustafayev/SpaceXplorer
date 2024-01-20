namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LaunchesController : ControllerBase
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();


    [HttpGet("{flightNumber}", Name = nameof(GetLaunchByFlightNumber))]
    public async Task<ActionResult<LaunchDto>> GetLaunchByFlightNumber(int flightNumber, CancellationToken ct)
    {
        return await Mediator.Send(new GetLaunchByFlightNumberQuery { FlightNumber = flightNumber }, ct);
    }


    [HttpGet(Name = nameof(GetLaunchesWithPagination))]
    public async Task<ActionResult<PaginatedList<LaunchDto>>> GetLaunchesWithPagination([FromQuery] GetLaunchesWithPaginationQuery query, CancellationToken ct)
    {
        return await Mediator.Send(query, ct);
    }
}