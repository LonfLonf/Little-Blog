using LivingAsIntern.Entities;
using LivingAsIntern.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingAsIntern.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            var posts = await _service.GetPosts();
            return Ok(posts);
        }

        [HttpGet("id/{Id}")]
        public async Task<ActionResult> GetPostById(int Id)
        {
            var post = await _service.GetPostsById(Id);
            return Ok(post);
        }

        [HttpGet("month/{Month}")]
        public async Task<ActionResult> GetAllPostsByMonth(int Month)
        {
            var post = await _service.GetPostsByMonth(Month);
            return Ok(post);
        }

        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            if (id != post.Id)
            {
                return BadRequest("Id Not Found");
            }

            var updatePost = await _service.UpdatePost(post);
            return Ok(updatePost);
        }

        [Authorize]
        [HttpDelete("delete/{Id}")]
        public async Task<ActionResult> DeletePost(int Id)
        {
            await _service.DeletePost(Id);
            return NoContent();
        }

        [Authorize]
        [HttpPost("admin/createpost")]
        public async Task<ActionResult> PostPost([FromBody] Post post)
        {
            var postCreate = await _service.CreatePost(post);
            return CreatedAtAction(nameof(GetPostById), new { id = postCreate.Id }, postCreate);
        }
    }
}
