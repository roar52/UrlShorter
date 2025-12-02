using Microsoft.AspNetCore.Mvc;
using UrlShorter.Services;

namespace UrlShorter.Controllers;

public class GetFullUrlController: Controller
{
    [HttpGet("/{slug}")]
    public IActionResult RedirectToFullUrl(string slug)
    {
        try
        {
            string url = MainLogic.GetLongUrlBySlug(slug);
            
            if (!IsValidRedirectUrl(url))
            {
                return BadRequest("Invalid redirect URL");
            }

            return Redirect(url);
        }
        catch (Exception)
        {
            return NotFound("Short URL not found");
        }
    }

    private bool IsValidRedirectUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }
        
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
        {
            return false;
        }

        if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            return false;
        }

        return true;
    }
}