namespace Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    [Test]
    public async Task Process_ShouldLogRequestInformation()
    {
        var mockLogger = CreateDefaultMockLogger();
        var loggingBehaviour = CreateDefaultLoggingBehaviour(mockLogger);
        var request = CreateGetLaunchByFlightNumberRequest();

        await loggingBehaviour.Process(request, CancellationToken.None);
       
        string expectedLogMessage = "SpaceXplorer RequestName: GetLaunchByFlightNumberQuery - Details: FlightNumber: 1";
        
        mockLogger.Verify(
            logger => logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((obj, type) => obj.ToString() == expectedLogMessage
                && type.Name == "FormattedLogValues"),
                null, (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
    }   

    private Mock<ILogger<LoggingBehaviour<GetLaunchByFlightNumberQuery>>> CreateDefaultMockLogger()
    {
        return new Mock<ILogger<LoggingBehaviour<GetLaunchByFlightNumberQuery>>>();
    }

    private LoggingBehaviour<GetLaunchByFlightNumberQuery> CreateDefaultLoggingBehaviour(Mock<ILogger<LoggingBehaviour<GetLaunchByFlightNumberQuery>>> mockLogger)
    {
        return new LoggingBehaviour<GetLaunchByFlightNumberQuery>(mockLogger.Object);
    }

    private GetLaunchByFlightNumberQuery CreateGetLaunchByFlightNumberRequest()
    {
        return new GetLaunchByFlightNumberQuery { FlightNumber = 1 };
    }
}