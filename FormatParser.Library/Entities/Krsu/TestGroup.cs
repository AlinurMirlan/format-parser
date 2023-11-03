using System.Reflection;
using System.Text;

namespace FormatParser.Library.Entities.Krsu;

public class TestGroup
{
    public int Id { get; set; }
    public int Points { get; set; }

    [EntityName("prereq")]
    public string? Prerequisites { get; set; }
}
