namespace SimpleBlog.Features.Comments.CreateComments
{
    public class InputCreateComment
    {
        public Guid IdPost { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
