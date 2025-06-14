using SocialMediaFinal.Backend.Domain.Entities.Post;

namespace SocialMediaFinal.Backend.Application.Features.Auth.Account.Posts.GetAllPosts;

public sealed record GetAllPostsResponse(IEnumerable<PostEntity> posts);
