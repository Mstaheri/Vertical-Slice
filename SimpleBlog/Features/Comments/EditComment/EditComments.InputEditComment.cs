namespace SimpleBlog.Features.Comments.EditComment
{
    public class InputEditComment
    {
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
