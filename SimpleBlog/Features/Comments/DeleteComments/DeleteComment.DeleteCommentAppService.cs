using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;

namespace SimpleBlog.Features.DeleteComments
{
    public class DeleteCommentAppService : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IDbConnection _dbConnection;
        public DeleteCommentAppService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
           return Task.Run(async () =>
           {
                var query = "DELETE FROM Comments WHERE id = @id";
                await _dbConnection.QueryAsync(query, new { request.id });
           });
        }
    }
}
