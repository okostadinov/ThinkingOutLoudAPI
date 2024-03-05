using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Data;
using ThinkingOutLoud.Models;
using ThinkingOutLoud.Services;

namespace ThinkingOutLoud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author?>> GetById(int id)
        {
            var author = await _service.GetById(id);
            if (author is null) return NotFound();

            return author;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            await _service.Create(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id}/updateusername")]
        public async Task<IActionResult> UpdateUsername(int id, string username)
        {
            var author = await _service.GetById(id);
            if (author is null) return NotFound();

            await _service.UpdateUsername(id, username);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _service.GetById(id);
            if (author is null) return NotFound();

            await _service.Delete(id);
            return NoContent();
        }
    }
}
