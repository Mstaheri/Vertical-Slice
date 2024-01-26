namespace SimpleBlog.Features.Posts.EditPosts
{
    public record InputPostEdit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
