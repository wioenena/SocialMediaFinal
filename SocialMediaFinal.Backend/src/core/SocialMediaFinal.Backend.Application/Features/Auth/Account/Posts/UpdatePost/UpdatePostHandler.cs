using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.UpdatePost;

public class UpdatePostHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePostRequest, UpdatePostResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    public async Task<UpdatePostResponse> Handle(UpdatePostRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<PostEntity>();
        var writeRepository = this.unitOfWork.GetWriteRepository<PostEntity>();
        var post = readRepository.GetByIdAsync(request.id).Result ?? throw new KeyNotFoundException($"Post with id {request.id} not found.");

        post.Content = request.content;
        post.Likes = request.likes;
        _ = writeRepository.Update(post);
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        return new UpdatePostResponse(post);
    }
}
