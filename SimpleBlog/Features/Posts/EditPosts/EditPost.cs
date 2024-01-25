using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBlog.Features.Posts.EditPosts
{
    [ApiController]
    [Route("api/posts")]
    public class EditPost : ControllerBase
    {
        [HttpPut]
        public async Task<ActionResult> Handler([FromBody]int a)
        {
            return Ok(new { a });
        }
    }
}
