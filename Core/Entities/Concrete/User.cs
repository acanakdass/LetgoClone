using Core.Attributes;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

[TableName("users")]
public class User : IEntity
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string password_hash { get; set; }
    public string password_salt { get; set; }
    public bool is_active { get; set; }
    
    public int address_id { get; set; }
}