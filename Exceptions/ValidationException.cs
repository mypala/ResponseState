using FluentValidation.Results;
using ResponseState.Enums;

namespace ResponseState.Exceptions;

public class ValidationException : Exception
{
    public StateCode StateCode { get; private set; }
    public Dictionary<string, string[]> ValidationErrors { get; private set; }

    public ValidationException(Dictionary<string, string[]> validationErrors) : base(StateCode.ValidationError.Message)
    {
        StateCode = StateCode.ValidationError;
        ValidationErrors = validationErrors ?? [];
    }

    public ValidationException(ValidationResult validationResult) : base(StateCode.ValidationError.Message)
    {
        StateCode = StateCode.ValidationError;
        ValidationErrors = validationResult?.Errors?
            .GroupBy(x => x.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage).ToArray()) ?? [];
    }

    public ValidationException(string message) : base(message)
    {
        StateCode = StateCode.ValidationError;
        ValidationErrors = [];
    }
}