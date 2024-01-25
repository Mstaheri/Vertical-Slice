using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.CreatePosts;

[ApiController]
[Route("api/posts")]
public class CreatePost : ControllerBase
{
    private readonly AppService _createPostAppService;
    private readonly IValidator<Input> _validator;

    public CreatePost(
        AppService createPostAppService,
        IValidator<Input> validator)
    {
        _createPostAppService = createPostAppService;
        _validator = validator;

    }
    [HttpPost]
    public async Task<ActionResult> Handler([FromBody] Input input)
    {
        var validationResult = _validator.Validate(input);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
        }
        await _createPostAppService.CreatePostAsync(input);
        return Ok();
    }
}
