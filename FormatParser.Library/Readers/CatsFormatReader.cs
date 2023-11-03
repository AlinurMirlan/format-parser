using FormatParser.Library.Entities.Cats;
using FormatParser.Library.Infrastructure;

namespace FormatParser.Library.Readers;

public class CatsFormatReader : FormatReader
{
    public CatsFormatReader(ParseFile<Cats> parseCats)
    {
        ParseCats = parseCats;
    }

    public ParseFile<Cats> ParseCats { get; set; }

    private Cats Parse(DirectoryInfo formatDirectory) => Parse(formatDirectory, ParseCats);

    public override void OutputInfo(Stream outputStream, DirectoryInfo formatDirectory)
    {
        using StreamWriter writer = new(outputStream);
        Cats testInfo = Parse(formatDirectory);
        writer.Write(testInfo.StringifyEntity(0));
    }
}
