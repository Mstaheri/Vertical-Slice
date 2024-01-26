using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.CreatePosts;

[ApiController]
[Route("api/posts")]
public class CreatePost : ControllerBase
{
    private readonly AppServicePostCreate _createPostAppService;
    private readonly IValidator<InputPostCreate> _validator;

    public CreatePost(
        AppServicePostCreate createPostAppService,
        IValidator<InputPostCreate> validator)
    {
        _createPostAppService = createPostAppService;
        _validator = validator;

    }
    [HttpPost]
    public async Task<ActionResult> Handler([FromBody] InputPostCreate input)
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
