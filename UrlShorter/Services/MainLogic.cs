using UrlShorter.Repositories;

namespace UrlShorter.Services;

public static class MainLogic
{
    private const int MAX_RETRY_ATTEMPTS = 5;

    public static string GenerateShortUrl(string longUrl)
    {
        string slug;
        int attempts = 0;

        do
        {
            slug = LogicHelper.GenerateSlug();
            attempts++;

            if (attempts >= MAX_RETRY_ATTEMPTS)
            {
                throw new InvalidOperationException($"Failed to generate unique slug after {MAX_RETRY_ATTEMPTS} attempts");
            }
        }
        while (ShortUrlsRepository.SlugExists(slug));

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