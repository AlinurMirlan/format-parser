using FormatParser.Library.CaseConvertors;

namespace FormatParser.Library.Parsers.FileParsers.Ejudge;

public class ValuerParser<TEntity> : FileParser<TEntity> where TEntity : class
{
    protected override ICaseConvertor? CaseConvertor { get; set; } = new CamelToSnake();

    protected override Dictionary<string, object> ExtractNameValuePairs(Stream fileStream)
    {
        throw new NotImplementedException();
    }
}
