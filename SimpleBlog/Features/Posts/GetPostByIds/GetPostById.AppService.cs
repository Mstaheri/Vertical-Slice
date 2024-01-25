using Dapper;
using SimpleBlog.Infrastructure;
using System.Data;

namespace SimpleBlog.Features.Posts.GetPostByIds;
public class AppService
{
    private readonly BlogDbContext _connection;

    public AppService(
        BlogDbContext connection)
	{
		_connection = connection;
	}

	public async Task<Response> Handler(string title)
	{
		//return await _connection.QueryFirstAsync<Response>(
		//	"SELECT Id, Title, Content FROM Posts");
		var post = await _connection.Posts.FindAsync(title)
			?? throw new Exception("Not Found");
		return new Response
		{
			Id = post.Id,
			Title = post.Title,
			Content = post.Content,
		};
	}
}
