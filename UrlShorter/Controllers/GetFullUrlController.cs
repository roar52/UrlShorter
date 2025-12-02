using Microsoft.AspNetCore.Mvc;
using UrlShorter.Services;

namespace UrlShorter.Controllers;

public class GetFullUrlController: Controller
{
    [HttpGet("/{slug}")]
    public RedirectResult RedirectToFullUrl(string slug)
    {
        try
        {
            string url = MainLogic.GetLongUrlBySlug(slug);
            return Redirect(url);
        }
        catch (Exception ex)
        {
            throw new HttpProtocolException(404, "Page not found", ex);
        }
    }
}