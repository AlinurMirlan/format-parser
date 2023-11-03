using FormatParser.Library.Entities.Cats;
using FormatParser.Library.Entities.Ejudge;
using FormatParser.Library.Entities.Krsu;
using FormatParser.Library.Entities.Pcms2;
using FormatParser.Library.Formats.Grammar;
using FormatParser.Library.Formats.Parsers;
using FormatParser.Library.Formats.Parsers.Ejudge;
using FormatParser.Library.Readers;
using FormatParser.Library.Sources;
using Sprache;
using System.Runtime.Serialization;

namespace FormatParser;

public class Program
{
    private const string OutputDirectory = "temp";
    private const string HelperText = """
        
        This utility tool parses different programming task formats 
        and outputs information about them.
        Arguments:
        1st - Format to parse. Takes one of the following values { krsu, ejudge }
        2nd - Path to the format .zip package
        """
    ;

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine($"Not enough arguments. {HelperText}");
            return;
        }

        string format = args[0];
        string formatPath = args[1];
        FormatReader formatReader;
        IFormatSource formatSource;
        try
        {
            formatReader = format switch
            {
                "krsu" => new KrsuFormatReader(
                            new ParseFile<TestInfo>(
                                new XmlParser<TestInfo>(),
                                "testinfo.xml")),
                "ejudge" => new EjudgeFormatReader(
                                new ParseFile<EjudgeProblem>(
                                    new ProblemParser<EjudgeProblem>(),
                                    "problem.cfg"),
                                new ParseFile<Valuer>(
                                    new ValuerParser<Valuer>(),
                                    "valuer.cfg")),
                "pcms2" => new Pcms2FormatReader(
                            new ParseFile<Pcms2Problem>(
                                new XmlParser<Pcms2Problem>(),
                                "problem.xml")),
                "cats" => new CatsFormatReader(
                            new ParseFile<Cats>(
                                new CatsParser<Cats>(),
                                "*.xml")),
                _ => throw new ArgumentException("Unknown format.")
            };
            formatSource = Path.GetExtension(formatPath) switch
            {
                ".zip" => new ZipFileSource(OutputDirectory),
                "" when Directory.Exists(formatPath) => new FolderSource(),
                _ => throw new ArgumentException("Unknown package source format.")
            };
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"{exception.Message} {HelperText}");
            return;
        }

        try
        {
            formatReader.OutputInfo(
                Console.OpenStandardOutput(),
                formatSource.Open(formatPath));
        }
        catch (Exception exception) when 
            (exception is FileNotFoundException ||
            exception is SerializationException)
        {
            Console.WriteLine(exception.Message);
        }

        ClearTempFolder();
    }

    static void ClearTempFolder() => Directory.Delete(OutputDirectory, true);
}