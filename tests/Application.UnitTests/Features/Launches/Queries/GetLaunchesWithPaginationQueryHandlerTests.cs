namespace Application.UnitTests.Features.Launches.Queries;

public class GetLaunchesWithPaginationQueryHandlerTests
{
    [Test]
    public async Task Handle_ReturnsPaginatedListOfLaunchDto()
    {       
        var mockLaunchService = new Mock<ISpaceXLaunchService>();

        var paginatedLaunchDtoList = new PaginatedList<LaunchDto>(); 
        mockLaunchService.Setup(service =>
                service.GetLaunchesAsync(It.IsAny<int>(), It.IsAny<int>(), CancellationToken.None, It.IsAny<string>()))
            .ReturnsAsync(paginatedLaunchDtoList);

        var queryHandler = new GetLaunchesWithPaginationQueryHandler(mockLaunchService.Object);
        var query = new GetLaunchesWithPaginationQuery
        {
            RocketName = "Falcon 9",
            Limit = 10,
            Offset = 1
        };
                
        var result = await queryHandler.Handle(query, CancellationToken.None);
               
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(paginatedLaunchDtoList));      
    }
}