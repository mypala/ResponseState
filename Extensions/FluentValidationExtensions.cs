using FluentValidation;
using ValidationException = ResponseState.Exceptions.ValidationException;

namespace ResponseState.Extensions;

public static class FluentValidationExtensions
{
    public static async Task ValidateAndThrowCustom<T>(this IValidator<T> validator, T instance, CancellationToken cancellationToken = default)
    {
        var result = await validator.ValidateAsync(instance, cancellationToken);
        if (!result.IsValid)
            throw new ValidationException(result);
    }
}