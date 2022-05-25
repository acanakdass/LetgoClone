using Core.Attributes;
using Core.Entities.Abstract;

namespace Entity;

[TableName("categories")]
public class Category : IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}