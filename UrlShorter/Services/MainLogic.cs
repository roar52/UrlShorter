using UrlShorter.Repositories;

namespace UrlShorter.Services;

public static class MainLogic
{
    public static string GenerateShortUrl(string longUrl)
    {
        string slug = LogicHelper.GenerateSlug();
        ShortUrlsRepository.AddSlug(slug, longUrl);
        return slug;
    }

    public static string GetLongUrlBySlug(string slug)
    {
        string? url = ShortUrlsRepository.GetLongUrlBySlug(slug);
        if (string.IsNullOrEmpty(url))
        {
            throw new KeyNotFoundException($"Short URL with slug '{slug}' not found");
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