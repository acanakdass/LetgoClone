using Core.Attributes;
using Core.Entities.Abstract;

namespace Entity;

[TableName("photos")]
public class Photo:IEntity
{
    public int id { get; set; }
    public string file_path { get; set; }
    public int advert_id { get; set; }
}