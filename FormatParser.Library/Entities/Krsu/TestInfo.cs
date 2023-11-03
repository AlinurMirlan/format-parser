namespace FormatParser.Library.Entities.Krsu;

[EntityName("testinfo")]
public class TestInfo
{
    public required string Checker { get; set; }
    public string? Interactor { get; set; }

    [EntityName("problem")]
    public string? ProblemStatement { get; set; }

    [EntityName("memorylimit")]
    public int MemoryLimitByte { get; set; }

    [EntityName("timelimit")]
    public int TimeLimitMilli { get; set; }

    [EntityName("testversion")]
    public int TestVersion { get; set; }

    [EntityName("runtype")]
    public int RunType { get; set; }

    [EntityName("group")]
    public List<TestGroup> Groups { get; set; } = new List<TestGroup>();

    [EntityName("test")]
    public List<Test> Tests { get; set; } = new List<Test>();
}
