using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Features.Posts.DeletePosts;

namespace SimpleBlog.Features.Posts.DeletePost
{
    [ApiController]
    [Route("api/posts")]
    public class DeletePost : ControllerBase
    {
        private readonly AppService _appService;
        public DeletePost(AppService appService)
        {
            _appService = appService;
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> Handler(Guid id)
        {
            var result = await _appService.DeletePostAsync(id);
            return Ok(result.Success);
        }
    }
}
