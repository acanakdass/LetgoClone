using Core.Attributes;
using Core.Entities.Abstract;

namespace Entity;

[TableName("adverts")]
public class Advert:IEntity
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int user_id { get; set; }
    public decimal price { get; set; }
    public int status_id { get; set; }
    public bool is_new { get; set; }
    public bool is_active { get; set; }
    public bool is_sold { get; set; }
    public int category_id { get; set; }
    public bool is_deleted { get; set; }
    public bool is_tradable { get; set; }
    public DateTime created_date { get; set; }
    public DateTime updated_date { get; set; }
}

