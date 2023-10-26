using System.Text;

namespace FormatParser.Library.CaseConvertors;

public class CamelToSnake : ICaseConvertor
{
    public string Convert(string identificator)
    {
        if (string.IsNullOrEmpty(identificator))
            return string.Empty;

        StringBuilder tokenBuilder = new();
        StringBuilder snakeBuilder = new();
        for (int i = 1; i < identificator.Length; i++)
        {
            char character = identificator[^i];
            if (char.IsUpper(character))
            {
                tokenBuilder.Append(char.ToLowerInvariant(character));
                string snakeToken = tokenBuilder.ToString();
                snakeBuilder.Insert(0, $"-{snakeToken}");
                tokenBuilder.Clear();
                continue;
            }

            tokenBuilder.Append(character);
        }

        return snakeBuilder.ToString()[1..];
    }
}
