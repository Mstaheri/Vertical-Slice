using MediatR;
using Dapper;
using SimpleBlog.Infrastructure;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Features.Comments.GetComments
{
    public class GetCommentAppService : IRequestHandler<GetCommentCommand,GetCommentInput>
    {
        private readonly IDbConnection _DbContext;
        public GetCommentAppService(IDbConnection dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<GetCommentInput> Handle(GetCommentCommand request, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Comments WHERE id = @id";
            var result = await _DbContext.QueryFirstOrDefaultAsync<GetCommentInput>(query, new {request.Id});
            return result;
        }
    }
}
