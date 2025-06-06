using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Application.Interfaces.Services;
using SocialMediaFinal.Backend.Domain.Entities.Account;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.CreateAccount;

internal sealed class CreateAccountHandler(IUnitOfWork unitOfWork, IPasswordService passwordService) : IRequestHandler<CreateAccountRequest, CreateAccountResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPasswordService passwordService = passwordService;

    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken) {
        var writeRepository = this.unitOfWork.GetWriteRepository<AccountEntity>();

        AccountEntity account = new() {
            Username = request.username!,
            Password = this.passwordService.Hash(request.password!),
            FullName = request.fullName!,
        };

        _ = await writeRepository.AddAsync(account);
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateAccountResponse(account.Id);
    }
}
