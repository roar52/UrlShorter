namespace UrlShorter.Services;

public static class LogicHelper
{
    private static readonly char[] ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToArray();
    public static string GenerateSlug()
    {
        Random random = new Random();
        string slug = string.Empty;
        for (int i = 0; i < 6; i++)
        {
            slug += ALPHABET[random.Next(0, ALPHABET.Length)];
        }
        return slug;
    }
}