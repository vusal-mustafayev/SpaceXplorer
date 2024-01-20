namespace Application.UnitTests.Common.Behaviours;

public class ValidationBehaviourTests
{
    private IPipelineBehavior<GetLaunchByFlightNumberQuery, int> _pipelineBehavior;
    private IValidator<GetLaunchByFlightNumberQuery> _validator;

    [SetUp]
    public void SetUp()
    {
        _validator = new GetLaunchByFlightNumberQueryValidator();
        _pipelineBehavior = new ValidationBehaviour<GetLaunchByFlightNumberQuery, int>(new[] { _validator });

    }

    [Test]
    public void Handle_WhenQueryIsEmpty_ThrowValidationException()
    {
        var query = new GetLaunchByFlightNumberQuery();
        Assert.That(() => _pipelineBehavior.Handle(query, null, CancellationToken.None), Throws.TypeOf<ValidationException>());
    }

    [Test]
    public void Handle_WhenQueryIsCorrect_ReturnHandlerResponse()
    {
        var query = new GetLaunchByFlightNumberQuery
        {
            FlightNumber = 1
        };

        var result = _pipelineBehavior.Handle(query, () => Task.FromResult(1), CancellationToken.None);

        Assert.That(result.Result, Is.EqualTo(1));
    }
}