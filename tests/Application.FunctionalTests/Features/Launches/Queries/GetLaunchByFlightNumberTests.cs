namespace Application.FunctionalTests.Features.Launches.Queries;

public class GetLaunchByFlightNumberTests
{    
    [Test]
    public async Task Handle_ValidFlightNumber_ReturnsLaunch()
    {
        var query = new GetLaunchByFlightNumberQuery
        {
            FlightNumber = 1
        };

        var result = await SendAsync(query);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.FlightNumber, Is.EqualTo(query.FlightNumber));
    }

    [Test]
    public void Handle_InvalidFlightNumber_ThrowsValidationException()
    {
        var query = new GetLaunchByFlightNumberQuery
        {
            FlightNumber = -1
        };

        var exception = Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(query));

        Assert.That(exception, Is.InstanceOf(typeof(ValidationException)));
        Assert.That(exception.Errors.ContainsKey(nameof(query.FlightNumber)));
    }

    [Test]
    public void Handle_FlightNumber_ThrowsNotFoundException()
    {
        var query = new GetLaunchByFlightNumberQuery
        {
            FlightNumber = 500
        };

        var exception = Assert.ThrowsAsync<NotFoundException>(async () => await SendAsync(query));

        Assert.That(exception, Is.InstanceOf(typeof(NotFoundException)));       
    }
}