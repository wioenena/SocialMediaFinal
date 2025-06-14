using FluentValidation;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.LoginAccount;

internal sealed class LoginValidator : AbstractValidator<LoginRequest> {
    public LoginValidator() {
        _ = this.RuleFor(r => r.username).NotEmpty().WithMessage("Username is required");
        _ = this.RuleFor(r => r.password).NotEmpty().WithMessage("Password is required");
    }
}
