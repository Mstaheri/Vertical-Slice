using Azure.Core;
using MediatR;

namespace SimpleBlog.Features.DeleteComments
{
    public class DeleteCommentCommand : IRequest
    {
        public required Guid id { get; init; }
    }
}
