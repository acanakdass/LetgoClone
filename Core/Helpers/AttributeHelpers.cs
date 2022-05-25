using Core.Attributes;

namespace Core.Helpers;

public static class AttributeHelpers
{
    public static string GetTableName<T>() where T:class
    {
        var tnAttribute = typeof(T).GetCustomAttributes(
            typeof(TableNameAttribute), true
        ).FirstOrDefault() as TableNameAttribute;
        if (tnAttribute != null)
        {
            return tnAttribute.tableName;
        }
        return null;
    }
}