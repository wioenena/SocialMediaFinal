using MediatR;
using SocialMediaFinal.Backend.Application.Interfaces;
using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.DeletePost;

public class DeletePostHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePostRequest, DeletePostResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    public async Task<DeletePostResponse> Handle(DeletePostRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<PostEntity>();
        var writeRepository = this.unitOfWork.GetWriteRepository<PostEntity>();
        var post = readRepository.GetByIdAsync(request.id).Result ?? throw new KeyNotFoundException($"Post with id {request.id} not found.");
        post.IsDeleted = true;
        _ = writeRepository.Update(post);
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeletePostResponse(request.id);
    }
}
