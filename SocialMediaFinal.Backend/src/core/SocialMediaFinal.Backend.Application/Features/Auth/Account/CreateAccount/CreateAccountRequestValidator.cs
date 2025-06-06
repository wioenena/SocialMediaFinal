using FluentValidation;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.CreateAccount;

public sealed class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest> {
    public CreateAccountRequestValidator() {
        _ = this.RuleFor(x => x.username).NotEmpty().WithMessage("Username is required.");

        _ = this.RuleFor(x => x.password).NotEmpty()
        .WithMessage("Password is required.");

        _ = this.RuleFor(x => x.fullName).NotEmpty()
        .WithMessage("Full name is required.");
    }
}
