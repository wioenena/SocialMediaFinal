using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetAllPosts;

public class GetAllPostsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPostsRequest, GetAllPostsResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;


    public async Task<GetAllPostsResponse> Handle(GetAllPostsRequest request, CancellationToken cancellationToken) {
        var postReadRepository = this.unitOfWork.GetReadRepository<PostEntity>();
        var posts = postReadRepository.GetQueryable(p => !p.IsDeleted, p => p.Author).ToList();

        return new GetAllPostsResponse(posts);

    }
}
