namespace WebAPI.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{

    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException }
            };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = (ValidationException)context.Exception;

        SetProblemDetailsResult(context, StatusCodes.Status400BadRequest,
           "ValidationException", GetValidationErrorDetails(exception.Errors.Values.First()),
           "https://tools.ietf.org/html/rfc7231#section-6.5.1");   
    }
     
    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundException)context.Exception;

        SetProblemDetailsResult(context, StatusCodes.Status404NotFound,
          "NotFound", exception.Message,
          "https://tools.ietf.org/html/rfc7231#section-6.5.4"); 
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        SetProblemDetailsResult(context, StatusCodes.Status500InternalServerError,
            "InternalServerError", "An error occurred while processing your request.",
            "https://tools.ietf.org/html/rfc7231#section-6.6.1");      
    }

    private void SetProblemDetailsResult(ExceptionContext context, int statusCode, string title, string detail, string type)
    {
        var details = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Type = type
        };

        if(statusCode == StatusCodes.Status404NotFound)
        {
            context.Result = new NotFoundObjectResult(details);
        }
        else
        {
            context.Result = new ObjectResult(details)
            {
                StatusCode = statusCode
            };
        }       

        context.ExceptionHandled = true;
    }

    private string GetValidationErrorDetails(string[] errors)
    {
        string details = "";

        foreach (var error in errors)
        {
            details += error + "\n";
        }

        return details;
    }
}