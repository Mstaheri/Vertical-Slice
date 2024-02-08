using MediatR;

namespace SimpleBlog.Features.Comments.GetComments
{
    public class GetCommentCommand : IRequest<GetCommentInput>
    {
        public required Guid Id { get; init; }
    }
}
