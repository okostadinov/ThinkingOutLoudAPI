using Microsoft.AspNetCore.Mvc;
using ThinkingOutLoud.Models;
using ThinkingOutLoud.Services;

namespace ThinkingOutLoud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase {
    private readonly TagService _service;

    public TagController(TagService service) {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetAll() {
        return await _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tag?>> GetById(int id) {
        var tag = await _service.GetById(id);

        if (tag is null) return NotFound();

        return tag;
    }

    [HttpPost]
    public async Task<ActionResult<Tag>> Create(Tag tag) {
        var newTag = await _service.Create(tag);

        return CreatedAtAction(nameof(GetById), new {id = newTag.Id}, newTag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        var tag = await _service.GetById(id);

        if (tag is null) return NotFound();

        await _service.Delete(id);
        return NoContent();
    }
}