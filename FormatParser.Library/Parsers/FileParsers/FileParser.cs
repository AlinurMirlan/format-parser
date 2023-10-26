using FormatParser.Library.CaseConvertors;
using System.Reflection;

namespace FormatParser.Library.Parsers.FileParsers;

public abstract class FileParser<TEntity> where TEntity : class
{
    public TEntity? Parse(string filePath) => ConvertToEntity(File.OpenRead(filePath));

    public TEntity? Parse(Stream fileStream) => ConvertToEntity(fileStream);

    protected abstract ICaseConvertor? CaseConvertor { get; set; }

    protected abstract Dictionary<string, object> ExtractNameValuePairs(Stream fileStream);

    protected TEntity? ConvertToEntity(Stream stream)
    {
        Dictionary<string, object> nameValuePairs = ExtractNameValuePairs(stream);
        return BuildEntity(typeof(TEntity), nameValuePairs) as TEntity;
    }

    protected object BuildEntity(Type entityType, Dictionary<string, object> nameValuePairs)
    {
        object entity = Activator.CreateInstance(entityType)
            ?? throw new InvalidOperationException("Could not isntantiate an entity class.");
        foreach (PropertyInfo propertyInfo in entityType.GetProperties())
        {
            string name;
            Type propertyType = propertyInfo.GetType();
            Attribute? attribute = propertyInfo.GetCustomAttribute(typeof(InFileNameAttribute));
            if (attribute is InFileNameAttribute inFileNameAttribute)
                name = inFileNameAttribute.InFileName;
            else
                name = CaseConvertor?.Convert(propertyInfo.Name) ?? propertyInfo.Name;

            if (nameValuePairs.TryGetValue(name, out object? value))
            {
                if (!propertyType.IsPrimitive && propertyType != typeof(string) && propertyType != typeof(decimal))
                {
                    Dictionary<string, object> innerNameValuePairs = value as Dictionary<string, object>
                        ?? throw new InvalidOperationException("No inner name-value dictionary for an inner entity defined.");
                    propertyInfo.SetValue(entity, BuildEntity(propertyType, innerNameValuePairs));
                    continue;
                }

                object converted = Convert.ChangeType(value, propertyInfo.PropertyType);
                propertyInfo.SetValue(entity, converted);
            }
        }

        return entity;
    }
}
