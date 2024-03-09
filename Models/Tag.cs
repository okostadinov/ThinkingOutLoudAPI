using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThinkingOutLoud.Models;

public class Tag
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Blog> Blogs { get; set; } = [];
}