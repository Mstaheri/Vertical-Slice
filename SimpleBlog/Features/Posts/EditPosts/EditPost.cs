using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBlog.Features.Posts.EditPosts
{
    [ApiController]
    [Route("api/posts")]
    public class EditPost : ControllerBase
    {
        private readonly AppService _appService;
        private readonly Validator _validator;
        public EditPost(AppService appService , Validator validator)
        {
            _appService = appService;
            _validator = validator;
        }
        //[HttpPut()]
        //public async Task<ActionResult> Handler([FromBody] Input input)
        //{
        //    var result = _validator.Validate(input);
        //    if (!result.IsValid)
        //    {
        //        return BadRequest(result.ToDictionary());
        //    }
        //    var result1 = await _appService.EditPostAsync(input);
        //    return Ok(result1.Success);
        //}
    }
}
