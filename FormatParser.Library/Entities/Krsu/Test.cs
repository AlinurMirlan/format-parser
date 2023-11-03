using System.Reflection;
using System.Text;

namespace FormatParser.Library.Entities.Krsu;

public class Test
{
    [EntityName("input")]
    public required string InputFile { get; set; }

    [EntityName("output")]
    public required string OutputFile { get; set; }

    [EntityName("groupid")]
    public int GroupId { get; set; }
    public int Points { get; set; }
}
