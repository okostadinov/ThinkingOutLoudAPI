using Microsoft.AspNetCore.Mvc;
using ThinkingOutLoud.Models;
using ThinkingOutLoud.Services;

namespace ThinkingOutLoud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _service;

        public BlogController(BlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog?>> GetById(int id)
        {
            var blog = await _service.GetById(id);

            if (blog is null) return NotFound();

            return blog;
        }

        [HttpGet("authorid/{id}")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAllByAuthorId(int id)
        {
            return await _service.GetAllByAuthorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> Create(Blog newBlog)
        {
            var blog = await _service.Create(newBlog);
            if (blog is null) return BadRequest("Invalid author ID");

            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}/updatetitle")]
        public async Task<IActionResult> UpdateTitle(int id, string title)
        {
            var blogToUpdate = await _service.GetById(id);
            if (blogToUpdate is null) return NotFound();

            await _service.UpdateTitle(id, title);
            return NoContent();
        }

        [HttpPut("{id}/updatecontent")]
        public async Task<IActionResult> UpdateContent(int id, string content)
        {
            var blogToUpdate = await _service.GetById(id);
            if (blogToUpdate is null) return NotFound();

            await _service.UpdateContent(id, content);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _service.GetById(id);
            if (blog is null) return NotFound();

            await _service.Delete(id);
            return NoContent();
        }
    }
}
