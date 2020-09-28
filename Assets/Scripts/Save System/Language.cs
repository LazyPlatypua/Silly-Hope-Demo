
public struct Language
{
    public enum LanguageType
    {
        english,
        russian,
        german,
        french,
        esperanto
    }

    //Преобразовать из int в Language
    public static LanguageType IntToLanguage(int x)
    {
        return (LanguageType)x;
    }

    //Преобразовать из Language в int 
    public static int LanguageToInt(LanguageType l)
    {
        return (int)l;
    }
}
