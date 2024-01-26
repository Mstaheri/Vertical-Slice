namespace SimpleBlog.Features.Posts.GetPostByIds;

public record ResponseGetPostByIds
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Content { get; init; } = default!;
}
