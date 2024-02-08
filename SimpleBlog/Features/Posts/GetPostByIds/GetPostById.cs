using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.GetPostByIds;

[ApiController]
[Route("api/posts")]
public class GetPostById : ControllerBase
{
    private readonly AppServiceGetPostByIds _appService;

    public GetPostById(AppServiceGetPostByIds appService)
    {
        _appService = appService;
    }
    [HttpGet("{title}")]
    public async Task<ActionResult> Handler([FromRoute] string title)
    {
        return Ok(await _appService.GetPostAsync(title));
    }
}
