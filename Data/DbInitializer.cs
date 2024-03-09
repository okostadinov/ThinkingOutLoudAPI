using ThinkingOutLoud.Models;

namespace ThinkingOutLoud.Data;

public static class DbInitializer
{
    public static void Initialize(ThinkingOutLoudContext context)
    {
        if (context.Blogs.Any()
            && context.Authors.Any()
            && context.Tags.Any())
        {
            return;
        }

        var authors = new Author[] {
            new() {
                Username = "jimbeam",
            },
            new() {
                Username = "johnnywalker",
            },
        };

        var philosophyTag = new Tag() { Name = "philosophy" };
        var trainingTag = new Tag() { Name = "training" };
        var relationshipsTag = new Tag() { Name = "relationships" };

        var blogs = new Blog[] {
            new() {
                Title = "Mock blog 1",
                Content = "mock blog content",
                Author = authors[0],
                Tags = [philosophyTag]
            },
            new() {
                Title = "Mock blog 2",
                Content = "mock blog content",
                Author = authors[0],
                Tags = [philosophyTag, relationshipsTag]
            },
            new() {
                Title = "Mock blog 3",
                Content = "mock blog content",
                Author = authors[1],
                Tags = [trainingTag]
            },
        };

        context.Blogs.AddRange(blogs);
        context.SaveChanges();
    }
}