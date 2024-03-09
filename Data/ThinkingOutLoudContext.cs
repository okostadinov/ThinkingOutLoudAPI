using Microsoft.EntityFrameworkCore;
using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Data;

public class ThinkingOutLoudContext : DbContext
{
    public ThinkingOutLoudContext(DbContextOptions<ThinkingOutLoudContext> options) : base(options) { }
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Tag> Tags => Set<Tag>();

}