using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThinkingOutLoud.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Username { get; set; }
    
    [JsonIgnore]
    public ICollection<Blog>? Blogs { get; set; }

    public DateTime Registered { get; set; } = DateTime.UtcNow;
}