using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using SimpleBlog.Features.Comments.CreateComments;
using SimpleBlog.Features.Comments.EditComment;

namespace SimpleBlog.Features.Comments.EditComments
{
    [ApiController]
    [Route("api/Comments")]
    public class EditComments : ControllerBase
    {
        private readonly AppServiceEditComment _appServiceEditComment;
        private readonly IValidator<InputEditComment> _validator;
        public EditComments(AppServiceEditComment appServiceEditComment,
            IValidator<InputEditComment> validator)
        {
            _appServiceEditComment= appServiceEditComment;
            _validator= validator;
        }
        [HttpPut()]
        public async Task<ActionResult> Handler([FromBody] InputEditComment inputEditComment)
        {
            var query = _validator.Validate(inputEditComment);
            if (!query.IsValid)
            {
                return BadRequest(query.ToDictionary());
            }
            var result = await _appServiceEditComment.EditComment(inputEditComment);
            return Ok(result.Success);
        }
    }
}
