using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;
using System.Data;

namespace SimpleBlog.Features.Posts.GetPostByIds;
public class AppServiceGetPostByIds
{
    private readonly BlogDbContext _dbContext;

    public AppServiceGetPostByIds(
        BlogDbContext dbContext)
	{
        _dbContext = dbContext;
	}

	public async Task<OperationResult<ResponseGetPostByIds>> GetPostAsync(string title)
	{
		try
		{
            var post = await _dbContext.Posts.Where(p => p.Title == title).SingleAsync();
			return new OperationResult<ResponseGetPostByIds>
			{
				Success = true,
				data = new ResponseGetPostByIds
                {
					Id = post.Id,
					Title = post.Title,
					Content = post.Content,
				}
                
            };
        }
		catch (Exception)
		{
			return new OperationResult<ResponseGetPostByIds> { Success = false };
		}
		//return await _connection.QueryFirstAsync<Response>(
		//	"SELECT Id, Title, Content FROM Posts");
		
	}
}
