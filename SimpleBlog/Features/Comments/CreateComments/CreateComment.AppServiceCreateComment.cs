using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class AppServiceCreateComment
    {
        private readonly BlogDbContext _dbContext;
        public AppServiceCreateComment(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult> CreateCommentAsync(InputCreateComment input)
        {
            try
            {
                var Comment = new Comment(input.Name, input.Text, input.IdPost);
                await _dbContext.AddAsync(Comment);
                await _dbContext.SaveChangesAsync();
                return new OperationResult
                {
                    Success = true,
                };
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Success = false,
                };
            }
            
        }
    }
}
