using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.GetPostByIds;

[ApiController]
[Route("api/posts")]
public class GetPostById : ControllerBase
{
    private readonly AppService _appService;

    public GetPostById(AppService appService)
    {
        _appService = appService;
    }
    [HttpGet("/{Title}")]
    public async Task<ActionResult> Handler([FromRoute] string title)
    {
        return Ok(await _appService.Handler(title));
    }
}
