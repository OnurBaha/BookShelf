using FluentValidation.Results;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors.Select(error => new ValidationExceptionModel
        {
            Property = error.PropertyName,
            Errors = new List<string> { error.ErrorMessage }
        });
    }

    private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
    {
        var errorMessages = errors.Select(error => $"{error.PropertyName}: {error.ErrorMessage}");
        return string.Join(Environment.NewLine, errorMessages);
    }
}

public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
