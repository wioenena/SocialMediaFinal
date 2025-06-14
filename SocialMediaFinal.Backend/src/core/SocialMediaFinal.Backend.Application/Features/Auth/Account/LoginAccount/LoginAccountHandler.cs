using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Application.Interfaces.Services;
using SocialMediaFinal.Backend.Domain.Entities.Account;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.LoginAccount;

public class LoginAccountHandler(
    IUnitOfWork unitOfWork, IPasswordService passwordService, IJWTService jwtService
) : IRequestHandler<LoginRequest, LoginResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPasswordService passwordService = passwordService;
    private readonly IJWTService jwtService = jwtService;

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<AccountEntity>();
        var account = await readRepository.FindByExpressionAsync(a => a.Username == request.username) ?? throw new Exception("Account not found");

        if (!this.passwordService.Validate(request.password, account.Password)) {
            throw new Exception($"Invalid password for account with username or email '{request.username}'.");
        }

        var accessToken = this.jwtService.GenerateAccessToken(account.Id.ToString());
        account.AccessToken = accessToken;
        account.LastLoginAt = DateTime.UtcNow;
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        return new(account.Id, accessToken);
    }
}
