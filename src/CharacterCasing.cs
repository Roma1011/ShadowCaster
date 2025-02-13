namespace ShadowCaster;

public enum CharacterCasing
{
    Normal=0,
    Lower=1,
    Upper=2
}

internal sealed class CharacterCaster
{
    internal static string Cast(string value, CharacterCasing characterCasing) => characterCasing switch
    {
        CharacterCasing.Upper => value.ToUpper(),
        CharacterCasing.Lower => value.ToLower(),
        _ => value
    };
}