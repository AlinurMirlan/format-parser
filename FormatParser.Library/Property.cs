namespace FormatParser.Library;

public class Property : Item
{
    public Property(object? value)
    {
        Value = value;
    }

    public object? Value { get; set; }
}
