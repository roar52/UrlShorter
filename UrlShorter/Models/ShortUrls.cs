using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UrlShorter.Models;

[Table("short_urls")]
[PrimaryKey(nameof(Slug))]
public class ShortUrls: DbContext
{
    public string Slug { get; set; }
    public string? LongUrl { get; set; }
}