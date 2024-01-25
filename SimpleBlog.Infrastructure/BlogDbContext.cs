using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure.Config;

namespace SimpleBlog.Infrastructure;

public class BlogDbContext : DbContext
{
	public BlogDbContext(DbContextOptions<BlogDbContext> options)
		: base(options)
	{

	}
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new PostConfig());
        base.OnModelCreating(modelBuilder);
    }


}
