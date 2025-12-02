using System.Security.Cryptography;
using System.Text;

namespace UrlShorter.Services;

public static class LogicHelper
{
    private static readonly char[] ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToArray();
    private const int SLUG_LENGTH = 6;

    public static string GenerateSlug()
    {
        StringBuilder slug = new StringBuilder(SLUG_LENGTH);

        for (int i = 0; i < SLUG_LENGTH; i++)
        {
            int randomIndex = RandomNumberGenerator.GetInt32(0, ALPHABET.Length);
            slug.Append(ALPHABET[randomIndex]);
        }

        return slug.ToString();
    }
}