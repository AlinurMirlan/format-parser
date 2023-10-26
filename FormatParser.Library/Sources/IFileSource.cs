namespace FormatParser.Library.Sources;

public interface IFileSource
{
    public DirectoryInfo Open(string filePath, string outPath);
}
