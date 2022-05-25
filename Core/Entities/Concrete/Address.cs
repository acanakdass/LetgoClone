using Core.Attributes;

namespace Core.Entities.Concrete;

[TableName("addresses")]
public class Address
{
    public int id { get; set; }
    public int name { get; set; }
    public int city_id { get; set; }
    public int country_id { get; set; }
    public string mailing_address { get; set; }
}