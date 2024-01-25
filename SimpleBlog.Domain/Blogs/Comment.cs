namespace SimpleBlog.Domain.Blogs;

public class Comment
{
    public Comment(string name, string text)
    {
        Id = Guid.NewGuid();
        Name = name;
        Text = text;
    }
    public Guid Id { get; private set; }
    public Guid IdPost { get; private set; }
    public string Name { get; private set; }
    public string Text { get; private set; }
    public Post Posts { get; set; }


}
