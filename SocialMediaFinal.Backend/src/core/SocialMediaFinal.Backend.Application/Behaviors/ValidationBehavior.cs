using FluentValidation;
using MediatR;

namespace SocialMediaFinal.Backend.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class {
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        ArgumentNullException.ThrowIfNull(next);

        if (validators.Any()) {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(r => r.Errors)
                .Where(e => e is not null)
                .ToList();

            if (failures.Count > 0)
                throw new ValidationException(failures);
        }

        return await next(cancellationToken);
    }
}
