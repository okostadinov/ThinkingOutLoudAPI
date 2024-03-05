using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Data;

public static class DbInitializer
{
    public static void Initialize(ThinkingOutLoudContext context)
    {
        if (context.Blogs.Any() && context.Authors.Any()) return;

        var authors = new Author[] {
            new() {
                Username = "jimbeam",
            },
            new() {
                Username = "johnnywalker",
            },
        };

        var blogs = new Blog[] {
            new() {
                Title = "Mock blog 1",
                Content = "mock blog content",
                Author = authors[0]
            },
            new() {
                Title = "Mock blog 2",
                Content = "mock blog content",
                Author = authors[0]
            },
            new() {
                Title = "Mock blog 3",
                Content = "mock blog content",
                Author = authors[1]
            },
        };

        context.Blogs.AddRangeAsync(blogs);
        context.SaveChangesAsync();
    }
}