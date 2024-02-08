using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.DeleteComments
{
    [ApiController]
    [Route("api/Comments")]
    public class DeleteComment : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DeleteComment> _logger;
        public DeleteComment(IMediator mediator, ILogger<DeleteComment> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Handler(Guid id)
        {
            try
            {
                var command = new DeleteCommentCommand
                { id= id };
                await _mediator.Send(command);
                _logger.LogInformation("Delete Comment Successfully");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Eror DeleteComment Handler");
                return BadRequest(ex.Message);
            }
            
        }
    }
}
