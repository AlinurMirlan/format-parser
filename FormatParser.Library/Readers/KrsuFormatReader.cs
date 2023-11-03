using FormatParser.Library.Entities.Krsu;
using FormatParser.Library.Infrastructure;

namespace FormatParser.Library.Readers;

public class KrsuFormatReader : FormatReader
{
    public KrsuFormatReader(ParseFile<TestInfo> parseTest)
    {
        ParseTest = parseTest;
    }

    public ParseFile<TestInfo> ParseTest { get; set; }

    private TestInfo Parse(DirectoryInfo formatDirectory) => Parse(formatDirectory, ParseTest);

    public override void OutputInfo(Stream outputStream, DirectoryInfo formatDirectory)
    {
        using StreamWriter writer = new(outputStream);
        TestInfo testInfo = Parse(formatDirectory);
        writer.Write(testInfo.StringifyEntity(0));
    }
}
