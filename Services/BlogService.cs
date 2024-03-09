using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Data;
using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Services;

public class BlogService
{
    private readonly ThinkingOutLoudContext _context;

    public BlogService(ThinkingOutLoudContext context)
    {
        _context = context;
    }

    public Task<List<Blog>> GetAll()
    {
        return _context.Blogs.ToListAsync();
    }

    public Task<Blog?> GetById(int id)
    {
        return _context.Blogs
            .Include(b => b.Author)
            .Include(b => b.Tags)
            .AsNoTracking()
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public Task<List<Blog>> GetAllByAuthorId(int id)
    {
        return _context.Blogs
            .Where(b => b.Author != null && b.Author.Id == id)
            .ToListAsync();
    }

    public Task<List<Blog>> GetAllByTagId(int id)
    {
        return _context.Tags
            .Where(t => t.Id == id)
            .SelectMany(t => t.Blogs)
            .OrderBy(b => b.Published)
            .ToListAsync();
    }

    public async Task<Blog?> Create(Blog blog)
    {
        var author = await _context.Authors.FindAsync(blog.AuthorId);
        if (author is null) return null;

        blog.Author = author;
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
        return blog;
    }

    public async Task UpdateTitle(int id, string title)
    {
        var blog = await _context.Blogs.FindAsync(id);

        if (blog is not null)
        {
            blog.Title = title;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateContent(int id, string content)
    {
        var blog = await _context.Blogs.FindAsync(id);

        if (blog is not null)
        {
            blog.Content = content;
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var blog = await _context.Blogs.FindAsync(id);

        if (blog is not null)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}