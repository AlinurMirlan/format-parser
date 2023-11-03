using FormatParser.Library.Entities.Ejudge;
using FormatParser.Library.Infrastructure;

namespace FormatParser.Library.Readers;

public class EjudgeFormatReader : FormatReader
{
    public EjudgeFormatReader(ParseFile<EjudgeProblem> parseProblem, ParseFile<Valuer> parseValuer)
    {
        ParseProblem = parseProblem;
        ParseValuer = parseValuer;
    }

    public ParseFile<EjudgeProblem> ParseProblem { get; set; }
    public ParseFile<Valuer> ParseValuer { get; set; }

    public EjudgeInfo Parse(DirectoryInfo formatDirectory)
    {
        EjudgeInfo ejudgeInfo = new(
            Parse(formatDirectory, ParseProblem),
            Parse(formatDirectory, ParseValuer));
        return ejudgeInfo;
    }

    public override void OutputInfo(Stream outputStream, DirectoryInfo formatDirectory)
    {
        using StreamWriter writer = new(outputStream);
        EjudgeInfo ejudgeInfo = Parse(formatDirectory);
        writer.WriteLine(ejudgeInfo.StringifyEntity(0));
    }
}
