using FormatParser.Library.CaseConvertors;
using FormatParser.Library.Parsers.FileParsers;
using System.Runtime.Serialization;

namespace FormatParser.Library.Readers.Ejudge;

public class ProblemParser<TEntity> : FileParser<TEntity> where TEntity : class
{
    private const string LineComment = "#";
    private const string NameValueSeparator = "=";

    protected override ICaseConvertor? CaseConvertor { get; set; } = new CamelToSnake();

    protected override Dictionary<string, object> ExtractNameValuePairs(Stream fileStream)
    {
        StreamReader streamReader = new(fileStream);
        Dictionary<string, object> nameValuePairs = new();
        while (!streamReader.EndOfStream)
        {
            string line = streamReader.ReadLine() ?? string.Empty;
            if (line.StartsWith(LineComment))
                continue;

            string[] nameValue = line.Split(NameValueSeparator);
            if (nameValue.Length > 2)
                throw new SerializationException($"Incorrect format. The file contains more than one name-value separator {NameValueSeparator}");

            nameValuePairs.Add(nameValue[0], nameValue[1]);
        }

        return nameValuePairs;
    }
}
