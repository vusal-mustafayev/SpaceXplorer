namespace Application.UnitTests.Common.Exceptions;

public class ValidationExceptionTests
{
    [Test]
    public void Constructor_WithoutFailures_CreatesEmptyErrorDictionary()
    {
        var actual = new ValidationException().Errors;

        actual.Keys.Should().BeEmpty();
    }

    [Test]
    public void Constructor_SingleValidationFailure_CreatesSingleElementErrorDictionary()
    {
        var failures = new List<ValidationFailure>
        {
            new ValidationFailure("FlightNumber", "must be over 0"),
        };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().ContainSingle().Which.Should().Be("FlightNumber");
        actual["FlightNumber"].Should().ContainSingle().Which.Should().Be("must be over 0");

    }

    [Test]
    public void Constructor_MultipleValidationFailures_CreatesMultipleElementErrorDictionaryWithMultipleValues()
    {       
        var failures = new List<ValidationFailure>
        {
            new ValidationFailure("FlightNumber", "must not be null or empty"),
            new ValidationFailure("FlightNumber", "must be 0 or more"),
            new ValidationFailure("Limit", "must not be null or empty"),
            new ValidationFailure("Limit", "must be 1 or more"),

        };
       
        var actual = new ValidationException(failures).Errors;        

        actual.Keys.Should().HaveCount(2).And.ContainInOrder("FlightNumber", "Limit");
        actual["FlightNumber"].Should().HaveCount(2).And.ContainInOrder("must not be null or empty", "must be 0 or more");
        actual["Limit"].Should().HaveCount(2).And.ContainInOrder("must not be null or empty", "must be 1 or more");    
    }
}