using Microsoft.AspNetCore.Server.IIS.Core;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class AppService
{
    private readonly BlogDbContext _dbContext;

    public AppService(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> CreatePostAsync(Input input)
    {
        try
        {
            var post = new Post(input.Title, input.Content);
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post.Id;
        }
        catch
        {
            throw new Exception("eror");
        }
        
    }
}
