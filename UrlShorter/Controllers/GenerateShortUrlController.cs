using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UrlShorter.Repositories;
using UrlShorter.Services;

namespace UrlShorter.Controllers;

[Route("api/[controller]")]
public class GenerateShortUrlController: Controller
{
    [HttpPost("/short_url")]
    public string GenerateShortUrl([Required]string longUrl)
    {
        string slug = string.Empty;
        if(Uri.TryCreate(longUrl, UriKind.Absolute, out _))
        {
            slug = MainLogic.GenerateShortUrl(longUrl);
        }

        return slug;
    }

    [HttpPost("/human_url")]
    public string GenerateHumanUrl([Required] string longUrl, [Required] string shortUrlName)
    {
        if (Uri.TryCreate(longUrl, UriKind.Absolute, out _))
        {
            if (MainLogic.CreateHumanShortUrl(longUrl, shortUrlName))
            {
                return shortUrlName;
            }
        }

        return "";
    }
}