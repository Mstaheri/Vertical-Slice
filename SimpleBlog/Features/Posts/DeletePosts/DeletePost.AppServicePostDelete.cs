using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.DeletePosts
{
    public class AppServicePostDelete
    {
        private readonly BlogDbContext _dbContext;
        public AppServicePostDelete(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult> DeletePostAsync(Guid id)
        {
            try
            {
                var query = await _dbContext.Posts.Where(p => p.Id == id).SingleAsync();
                _dbContext.Posts.Remove(query);
                _dbContext.SaveChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
            
        }
    }
}
