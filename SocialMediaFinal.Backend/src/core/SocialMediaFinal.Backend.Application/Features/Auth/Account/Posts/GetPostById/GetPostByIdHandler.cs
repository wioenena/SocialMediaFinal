using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetPostById;

public class GetPostByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPostByIdRequest, GetPostByIdResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<GetPostByIdResponse> Handle(GetPostByIdRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<PostEntity>();
        var post = await readRepository.GetByIdAsync(request.id);
        return post is null ? throw new KeyNotFoundException($"Post with ID {request.id} not found.") : new GetPostByIdResponse(post);
    }
}
