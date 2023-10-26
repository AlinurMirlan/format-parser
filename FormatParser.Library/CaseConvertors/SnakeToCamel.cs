using System.Text;

namespace FormatParser.Library.CaseConvertors;

public class SnakeToCamel : ICaseConvertor
{
    private const string Separator = "_";

    public string Convert(string identificator)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string[] tokens = identificator.Split(Separator);
        foreach (string token in tokens)
        {
            stringBuilder.Append(ToTitleCase(token));
        }

        return stringBuilder.ToString();
    }

    private static string ToTitleCase(string token)
    {
        string lowerToken = token.ToLowerInvariant();
        return $"{char.ToUpper(lowerToken[0])}{lowerToken[1..]}";
    }
}
