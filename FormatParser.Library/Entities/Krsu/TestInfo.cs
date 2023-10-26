using System.Xml.Serialization;

namespace FormatParser.Library.Entities.Krsu;

[XmlRoot("testinfo")]
public class TestInfo
{
    [XmlElement("checker")]
    public required string Checker { get; set; }

    [XmlElement("interactor")]
    public string? Interactor { get; set; }

    [XmlElement("problem")]
    public string? ProblemStatement { get; set; }

    [XmlElement("memorylimit")]
    public int MemoryLimitByte { get; set; }

    [XmlElement("timelimit")]
    public int TimeLimitMilli { get; set; }

    [XmlElement("testversion")]
    public int TestVersion { get; set; }

    [XmlElement("runtype")]
    public int RunType { get; set; }

    [XmlElement("group")]
    public List<TestGroup> Groups { get; set; } = new List<TestGroup>();

    [XmlElement("test")]
    public List<Test> Tests { get; set; } = new List<Test>();
}
