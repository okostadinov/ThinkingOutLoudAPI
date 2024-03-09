using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Data;
using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Services;

public class TagService
{

    private readonly ThinkingOutLoudContext _context;

    public TagService(ThinkingOutLoudContext context)
    {
        _context = context;
    }

    public Task<List<Tag>> GetAll()
    {
        return _context.Tags.ToListAsync();
    }

    public Task<Tag?> GetById(int id)
    {
        return _context.Tags
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tag> Create(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task Delete(int id)
    {
        var tag = await _context.Tags.FindAsync(id);

        if (tag is not null)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }

    public bool Exists(string tagName)
    {
        return _context.Tags.Any(t => t.Name == tagName);
    }
}