namespace FormatParser.Library.Entities.Pcms2;

public class Pcms2Problem
{
    [ListWrapper]
    public List<Name>? Names { get; set; }

    [ListWrapper]
    public List<Statement>? Statements { get; set; }

    [ListWrapper]
    public List<Tutorial>? Tutorials { get; set; }
    public Judging? Judging { get; set; }
    public Files? Files { get; set; }
    public Assets? Assets { get; set; }

    [ListWrapper]
    public List<Property>? Properties { get; set; }
    public Stress? Stresses { get; set; }

    [ListWrapper]
    public List<Document>? Documents { get; set; }

    [ListWrapper]
    public List<Tag>? Tags { get; set; }
}
