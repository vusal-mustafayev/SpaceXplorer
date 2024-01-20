namespace Application.Features.Launches.DTOs;

public class LaunchDto
{
    public RocketDto Rocket { get; set; }
    public bool? LaunchSuccess { get; set; }
    public string Details { get; set; }
    public LinkDto Links { get; set; }
    public FailureDto LaunchFailureDetails { get; set; }
    public int FlightNumber { get; set; }
    public string MissionName { get; set; }
    public string LaunchDateUtc { get; set; }
    public bool? Upcoming { get; set; }
}