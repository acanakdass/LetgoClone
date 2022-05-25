using Core.Attributes;

namespace Core.Entities.Concrete;

[TableName("countries")]
public class Country
{
    public int id { get; set; }
    public string name { get; set; }
    public string country_code { get; set; }
}