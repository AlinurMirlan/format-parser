using System.Xml.Serialization;

namespace FormatParser.Library.Entities.Krsu;

public class Test
{
    [XmlAttribute("input")]
    public required string InputFile { get; set; }

    [XmlAttribute("output")]
    public required string OutputFile { get; set; }

    [XmlAttribute("groupid")]
    public int GroupId { get; set; }

    [XmlAttribute("points")]
    public int Points { get; set; }
}
