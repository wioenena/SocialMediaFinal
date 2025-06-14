using FluentValidation;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.CreatePost;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest> {
    public CreatePostRequestValidator() {
        _ = this.RuleFor(p => p.content)
            .NotEmpty()
            .WithMessage("Content cannot be empty.")
            .MaximumLength(500)
            .WithMessage("Content cannot exceed 500 characters.");

    }
}
