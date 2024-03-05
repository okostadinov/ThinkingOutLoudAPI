using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Data;
using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Services;

public class AuthorService
{
    private readonly ThinkingOutLoudContext _context;

    public AuthorService(ThinkingOutLoudContext context)
    {
        _context = context;
    }

    public Task<List<Author>> GetAll()
    {
        return _context.Authors.ToListAsync();
    }

    public Task<Author?> GetById(int id)
    {
        return _context.Authors
            .Include(a => a.Blogs)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task Create(Author author)
    {
        _context.Add(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUsername(int id, string username)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author is not null)
        {
            author.Username = username;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author is not null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}