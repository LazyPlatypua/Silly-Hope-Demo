
public struct Language
{
    public enum LanguageType
    {
        English,
        Russian,
        German,
        French,
        Esperanto
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
