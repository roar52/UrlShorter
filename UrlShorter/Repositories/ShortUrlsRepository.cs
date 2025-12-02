using UrlShorter.Models;

namespace UrlShorter.Repositories;

public static class ShortUrlsRepository
{
    public static void AddSlug(string slug, string longUrl)
    {
        using (DatabaseContext db = new DatabaseContext())
        {
            ShortUrls newSlug = new ShortUrls()
            {
                Slug = slug,
                LongUrl = longUrl
            };
 
            // добавляем их в бд
            db.ShortUrls.AddRange(newSlug);
            try
            {
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception("Такой короткий url уже существует");
            }
        }
    }
    
    public static string? GetLongUrlBySlug(string slug)
    {
        using (DatabaseContext db = new DatabaseContext())
        {
            var result = db.ShortUrls.Find(slug);
            return result?.LongUrl;
        }
    }
}