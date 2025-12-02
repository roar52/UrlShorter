using UrlShorter.Repositories;

namespace UrlShorter.Services;

public static class MainLogic
{
    public static string GenerateShortUrl(string longUrl)
    {
        string slug = LogicHelper.GenerateSlug();
        try
        {
            ShortUrlsRepository.AddSlug(slug, longUrl);
        }
        catch (Exception exception)
        {
            // ignored
        }

        return slug;
    }

    public static string GetLongUrlBySlug(string slug)
    {
        string? url = ShortUrlsRepository.GetLongUrlBySlug(slug);
        if (string.IsNullOrEmpty(url))
        {
            throw new Exception();
        }
        return url;
    }

    public static bool CreateHumanShortUrl(string longUrl, string shortUrlName)
    {
        if (ShortUrlsRepository.GetLongUrlBySlug(shortUrlName) == null)
        {
            ShortUrlsRepository.AddSlug(shortUrlName, longUrl);
            return true;
        }

        return false;
    }
}