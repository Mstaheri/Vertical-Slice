namespace SimpleBlog.Features.Posts.EditPosts
{
    public record Input
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
