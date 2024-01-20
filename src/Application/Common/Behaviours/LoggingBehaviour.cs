namespace Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger<LoggingBehaviour<TRequest>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var requestName = typeof(TRequest).Name;

            var properties = request.GetType().GetProperties();

            var propertyDetails = string.Join(", ", properties.Select(property => $"{property.Name}: {property.GetValue(request)}"));

            string logMessage = $"SpaceXplorer RequestName: {requestName} - Details: {propertyDetails}";

            _logger.LogInformation(logMessage);
        }
        catch (Exception ex)
        {
            EventId eventId = new EventId(ex.HResult);

            _logger.LogError(eventId, ex, ex.Message);
        }

        await Task.CompletedTask;
    }
}