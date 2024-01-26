using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBlog.Features.Posts.EditPosts
{
    [ApiController]
    [Route("api/posts")]
    public class EditPost : ControllerBase
    {
        private readonly AppServicePostEdit _appService;
        private readonly IValidator<InputPostEdit> _validator;
        public EditPost(AppServicePostEdit appService , IValidator<InputPostEdit> validator)
        {
            _appService = appService;
            _validator = validator;
        }
        [HttpPut()]
        public async Task<ActionResult> Handler([FromBody] InputPostEdit input)
        {
            var result = _validator.Validate(input);
            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }
            var result1 = await _appService.EditPostAsync(input);
            return Ok(result1.Success);
        }
    }
}
