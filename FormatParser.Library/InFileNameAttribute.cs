namespace FormatParser.Library;

[AttributeUsage(AttributeTargets.Property)]
public class InFileNameAttribute : Attribute
{
    public InFileNameAttribute(string name)
    {
        InFileName = name;
    }

    public string InFileName { get; set; }
}
