using System;

namespace Application.FunctionalTests.Features.Launches.Queries;

public class GetLaunchesWithPaginationTests
{
    [Test]
    public async Task Handle_ValidQuery_ReturnsPaginatedList()
    {
        var query = new GetLaunchesWithPaginationQuery
        {
            Offset = 0,
            Limit = 10,
            RocketName = ""
        };

        var result = await SendAsync(query);

        Assert.That(result, Is.Not.Null);
        Assert.That(query.Offset, Is.EqualTo(result.PageNumber));
        Assert.That(result.Launches.Any(launch => launch.FlightNumber == 1));
        Assert.That(result.Launches.Any(launch => launch.FlightNumber == 2));
    }

    [Test]
    public void Handle_InValidQuery_ThrowsValidationException()
    {
        var query = new GetLaunchesWithPaginationQuery
        {
            Offset = -1,
            Limit = -1
        };

        var exception =  Assert.ThrowsAsync<ValidationException>(async () => await SendAsync(query));

        Assert.That(exception, Is.InstanceOf(typeof(ValidationException)));
        Assert.That(exception.Errors.ContainsKey(nameof(query.Offset)));
        Assert.That(exception.Errors.ContainsKey(nameof(query.Limit)));
    }
}