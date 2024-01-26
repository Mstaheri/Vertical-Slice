using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Comments.CreateComments
{
    [ApiController]
    [Route("api/Comments")]
    public class CreateComment : ControllerBase
    {
        private readonly AppServiceCreateComment _appService;
        private readonly IValidator<InputCreateComment> _validator;
        public CreateComment(AppServiceCreateComment appService , IValidator<InputCreateComment> validator)
        {
            _appService= appService;
            _validator= validator;
        }
        [HttpPost]
        public async Task<ActionResult> Handler([FromBody] InputCreateComment input)
        {
            var result = _validator.Validate(input);
            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }
            await _appService.CreateCommentAsync(input);
            return Ok();
        }
    }
}
