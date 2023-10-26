using FormatParser.Library.Parsers.FileParsers;
using FormatParser.Library.FormatFiles.Krsu;
using System.Runtime.Serialization;

namespace FormatParser.Library.Parsers.FormatParsers;

public class KrsuFormatParser
{
    private readonly FileParser<TestInfo> _testInfoParser;

    public KrsuFormatParser(FileParser<TestInfo> testInfoParser, string testInfoFileName)
    {
        _testInfoParser = testInfoParser;
        TestInfoFileName = testInfoFileName;
    }

    public string TestInfoFileName { get; set; }

    public TestInfo Parse(DirectoryInfo formatDirectory)
    {
        FileInfo[] testInfoFiles = formatDirectory.GetFiles(TestInfoFileName);
        if (testInfoFiles.Length == 0)
            throw new FileNotFoundException("Test information file not found.");

        FileInfo testFile = testInfoFiles[0];
        TestInfo? testInfo = _testInfoParser.Parse(testFile.OpenRead())
            ?? throw new SerializationException("Test file could not be deserialized. Maka sure it's in the correct format.");
        return testInfo;
    }
}
