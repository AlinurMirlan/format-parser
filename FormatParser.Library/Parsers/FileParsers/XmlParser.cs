using FormatParser.Library.CaseConvertors;

namespace FormatParser.Library.Parsers.FileParsers;

public class XmlParser<T> : FileParser<T> where T : class, new()
{
    protected override ICaseConvertor? CaseConvertor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    protected override Dictionary<string, object> ExtractNameValuePairs(Stream fileStream)
    {
        throw new NotImplementedException();
    }
}
