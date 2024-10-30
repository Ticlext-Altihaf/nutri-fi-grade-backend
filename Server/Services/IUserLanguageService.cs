namespace Server.Services;

public interface IUserLanguageService
{
    List<string> GetUserLanguages();
    string GetUserLanguage();
}
