namespace Server.Services;

public class UserLanguageService : IUserLanguageService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserLanguageService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public List<string> GetUserLanguages()
    {
        var userLanguages = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"].ToString();

        if (string.IsNullOrEmpty(userLanguages))
            return new List<string>();

        return userLanguages.Split(',')
            .Select(lang => lang.Split(';'))
            .Select(parts => new
            {
                Language = parts[0],
                Quality = parts.Length > 1 ? double.Parse(parts[1].Split('=')[1]) : 1.0
            })
            .OrderByDescending(lang => lang.Quality)
            .Select(lang => lang.Language)
            .ToList();
    }

    public string GetUserLanguage()
    {
        var userLanguages = GetUserLanguages();
        return userLanguages.FirstOrDefault("en");
    }
}