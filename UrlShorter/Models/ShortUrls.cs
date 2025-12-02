using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShorter.Models;

[Table("short_urls")]
public class ShortUrls
{
    [Key]
    public string Slug { get; set; } = string.Empty;

    public string? LongUrl { get; set; }
}