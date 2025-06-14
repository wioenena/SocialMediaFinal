using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Account;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.GetMe;

public class GetMeHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetMeRequest, GetMeResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    public async Task<GetMeResponse> Handle(GetMeRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<AccountEntity>();
        var accountId = (this.httpContextAccessor.HttpContext?.User.FindFirst("id")?.Value) ?? throw new UnauthorizedAccessException("You must be logged in to access this resource.");

        var account = await readRepository.GetByIdAsync(Guid.Parse(accountId)) ?? throw new UnauthorizedAccessException("You must be logged in to access this resource.");

        return new GetMeResponse(account);
    }
}
