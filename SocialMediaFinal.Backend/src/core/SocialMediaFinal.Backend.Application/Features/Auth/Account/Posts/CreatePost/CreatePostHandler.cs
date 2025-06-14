using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.CreatePost;

public class CreatePostHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreatePostRequest, CreatePostResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

    public async Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken) {
        var postWriteRepository = this.unitOfWork.GetWriteRepository<PostEntity>();
        var user = this.httpContextAccessor.HttpContext?.User;
        var idClaim = (user?.FindFirst("id")) ?? throw new UnauthorizedAccessException("User is not authenticated.");
        var accountId = Guid.Parse(idClaim.Value);



        var post = new PostEntity {
            Content = request.content,
            AuthorId = accountId,
        };

        _ = await postWriteRepository.AddAsync(post);
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);


        return new CreatePostResponse(post);
    }
}
