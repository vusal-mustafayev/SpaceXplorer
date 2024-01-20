using Application.Common.Models;
using Application.Features.Launches.DTOs;
using System;

namespace Application.IntegrationTests.Services;

public class SpaceXLaunchServiceTests
{
    [Test]
    public async Task GetLaunches_ReturnsAllLaunches()
    {
        using (var client = new HttpClient())
        {
            var service = new SpaceXLaunchService(client);
            int limit = 1;
            int offset = int.MaxValue;

            var launches = await service.GetLaunchesAsync(limit, offset, CancellationToken.None);

            Assert.That(launches.TotalCount, Is.EqualTo(111));
        }
    }

    [Test]
    [TestCase(2, 10)]
    [TestCase(5, 8)]
    public async Task GetLaunches_WithPagination_ReturnsPaginatedLaunches(int limit, int offset)
    {
        PaginatedList<LaunchDto> result;

        using (var client = new HttpClient())
        {
            var service = new SpaceXLaunchService(client);

            result = await service.GetLaunchesAsync(limit, offset, CancellationToken.None);
        }

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf(typeof(PaginatedList<LaunchDto>)));
        Assert.That(result.PageNumber, Is.EqualTo(offset));
        Assert.That(result.Launches.Count, Is.EqualTo(limit));

    }

    [Test]
    [TestCase(10, 1, "Falcon 1")]
    [TestCase(10, 1, "Falcon 9")]
    public async Task GetLaunches_RocketName_ReturnsPaginatedRocketLaunches(int limit, int offset, string rocketName)
    {
        using (var client = new HttpClient())
        {
            var service = new SpaceXLaunchService(client);

            var result = await service.GetLaunchesAsync(limit, offset, CancellationToken.None, rocketName);

            Assert.That(result.Launches.All(launch => launch.Rocket.RocketName == rocketName));
        }
    }

    [Test]
    public async Task GetLaunchByFlightNumber_ValidFlightNumber_ReturnsLaunch()
    {
        using (var client = new HttpClient())
        {
            var service = new SpaceXLaunchService(client);
            var flightNumber = 1;

            var result = await service.GetLaunchByFlightNumberAsync(flightNumber, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.FlightNumber, Is.EqualTo(flightNumber));
        }
    }
}