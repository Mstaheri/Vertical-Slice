using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.EditPosts
{
    public class AppServicePostEdit
    {
        private readonly BlogDbContext _dbContext;
        public AppServicePostEdit(BlogDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<OperationResult> EditPostAsync(InputPostEdit input)
        {
            try
            {
                var query = await _dbContext.Posts.Where(p => p.Id == input.Id).SingleAsync();
                query.Edit(input.Title, input.Content);
                _dbContext.SaveChanges();
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
