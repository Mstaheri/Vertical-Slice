namespace SimpleBlog.Features.Posts.CreatePosts;

public record Input
{
    public string Title { get; init; } = default!;
    public string Content { get; init; } = default!;
}
