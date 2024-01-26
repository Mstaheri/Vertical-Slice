using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;
using System.Data;

namespace SimpleBlog.Features.Posts.GetPostByIds;
public class AppService
{
    private readonly BlogDbContext _dbContext;

    public AppService(
        BlogDbContext dbContext)
	{
        _dbContext = dbContext;
	}

	public async Task<OperationResult<Response>> GetPostAsync(string title)
	{
		try
		{
            var post = await _dbContext.Posts.Where(p => p.Title == title).SingleAsync();
			return new OperationResult<Response>
			{
				Success = true,
				data = new Response
				{
					Id = post.Id,
					Title = post.Title,
					Content = post.Content,
				}
                
            };
        }
		catch (Exception)
		{
			return new OperationResult<Response> { Success = false };
		}
		//return await _connection.QueryFirstAsync<Response>(
		//	"SELECT Id, Title, Content FROM Posts");
		
	}
}
