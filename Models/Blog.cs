using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThinkingOutLoud.Models;

public class Blog
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }

    [Required]
    public string? Content { get; set; }

    public DateTime Published { get; set; } = DateTime.UtcNow;

    [JsonIgnore]
    public int AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public bool IsPrivate { get; set; } = false;
}