namespace SimpleBlog.Features.Comments.GetComments
{
    public record GetCommentInput
    {
        public string Name { get; init; } = default!;
        public string Text { get; init; } = default!;
    }
}
