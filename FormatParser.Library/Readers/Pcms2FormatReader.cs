using FormatParser.Library.Entities.Pcms2;
using FormatParser.Library.Infrastructure;

namespace FormatParser.Library.Readers;

public class Pcms2FormatReader : FormatReader
{
    public Pcms2FormatReader(ParseFile<Pcms2Problem> parseProblem)
    {
        ParseProblem = parseProblem;
    }

    public ParseFile<Pcms2Problem> ParseProblem { get; set; }

    private Pcms2Problem Parse(DirectoryInfo formatDirectory) => Parse(formatDirectory, ParseProblem);

    public override void OutputInfo(Stream outputStream, DirectoryInfo formatDirectory)
    {
        using StreamWriter writer = new(outputStream);
        Pcms2Problem problem = Parse(formatDirectory);
        writer.Write(problem.StringifyEntity(0));
    }
}
