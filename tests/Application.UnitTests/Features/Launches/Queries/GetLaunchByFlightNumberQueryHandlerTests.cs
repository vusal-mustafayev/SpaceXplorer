namespace Application.UnitTests.Features.Launches.Queries;

public class GetLaunchByFlightNumberQueryHandlerTests
{
    [Test]
    public async Task Handle_ValidFlightNumber_ReturnsLaunch()
    {
        int validFlightNumber = 1;
        var mockLaunchService = new Mock<ISpaceXLaunchService>();
        mockLaunchService.Setup(service => service.GetLaunchByFlightNumberAsync(validFlightNumber, CancellationToken.None))
            .ReturnsAsync(new LaunchDto());

        var queryHandler = new GetLaunchByFlightNumberQuery.GetLaunchByFlightNumberQueryHandler(mockLaunchService.Object);
        var query = new GetLaunchByFlightNumberQuery { FlightNumber = validFlightNumber };

        var result = await queryHandler.Handle(query, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(LaunchDto)));
    }

    [Test]
    public void Handle_InvalidFlightNumber_ThrowsNotFoundException()
    {
        int invalidFlightNumber = 0;
        var mockLaunchService = new Mock<ISpaceXLaunchService>();
        mockLaunchService.Setup(service => service.GetLaunchByFlightNumberAsync(invalidFlightNumber, CancellationToken.None))
            .ReturnsAsync((LaunchDto)null);

        var queryHandler = new GetLaunchByFlightNumberQuery.GetLaunchByFlightNumberQueryHandler(mockLaunchService.Object);
        var query = new GetLaunchByFlightNumberQuery { FlightNumber = invalidFlightNumber };

        Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await queryHandler.Handle(query, CancellationToken.None);
        });
    }

    [Test]
    public void Handle_InvalidFlightNumber_ThrowsValidationException()
    {
        int invalidFlightNumber = -1;
        var mockLaunchService = new Mock<ISpaceXLaunchService>();
        mockLaunchService.Setup(service => service.GetLaunchByFlightNumberAsync(invalidFlightNumber, CancellationToken.None))
           .ThrowsAsync(new ValidationException());

        var queryHandler = new GetLaunchByFlightNumberQuery.GetLaunchByFlightNumberQueryHandler(mockLaunchService.Object);
        var query = new GetLaunchByFlightNumberQuery { FlightNumber = invalidFlightNumber };

        Assert.ThrowsAsync<ValidationException>(async () =>
        {
            await queryHandler.Handle(query, CancellationToken.None);
        });
    }
}