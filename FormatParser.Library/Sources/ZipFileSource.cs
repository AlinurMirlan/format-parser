using System.IO.Compression;

namespace FormatParser.Library.Sources;

public class ZipFileSource : IFileSource
{
    public DirectoryInfo Open(string filePath, string outPath)
    {
        ZipArchive zipArchive = ZipFile.OpenRead(filePath);
        zipArchive.ExtractToDirectory(outPath);
        return new DirectoryInfo(outPath);
    }
}
