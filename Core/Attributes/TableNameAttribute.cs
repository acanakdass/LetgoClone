namespace Core.Attributes;

public class TableNameAttribute : Attribute
{
    public string tableName;
    public TableNameAttribute(string name)
    {
        tableName = name;
    }
}