using Core.Attributes;

namespace Core.Entities.Concrete;

[TableName("cities")]
public class City
{
    public int id { get; set; }
    public string name { get; set; }
    public int country_id  { get; set; }
}