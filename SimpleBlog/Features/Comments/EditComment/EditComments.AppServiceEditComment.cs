using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.EditComment
{
    public class AppServiceEditComment
    {
        private readonly BlogDbContext _dbContext;
        public AppServiceEditComment(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResult> EditComment(InputEditComment inputEditComment)
        {
            try
            {
                var query = await _dbContext.Comments
                .Where(p => p.Id == inputEditComment.Id && p.IdPost == inputEditComment.IdPost)
                .SingleAsync();
                query.Edit(inputEditComment.Name, inputEditComment.Text);
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
