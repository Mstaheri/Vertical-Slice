using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Features.Posts.GetPostByIds;

namespace SimpleBlog.Features.Comments.GetComments
{
    [ApiController]
    [Route("api/Comments")]
    public class GetComment : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ILogger<GetComment> _logger;
        public GetComment(IMediator mediatR, ILogger<GetComment> logger)
        {
            _mediatR = mediatR;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Handler([FromRoute]Guid id)
        {
            try
            {
                GetCommentCommand commend = new GetCommentCommand
                {
                    Id = id
                };
                var result = await _mediatR.Send(commend);
                _logger.LogInformation("get Post Successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Eror in GetComment Handler");
                return BadRequest(ex);
            }
            
        }

    }
}
