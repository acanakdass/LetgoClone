using Core.Entities.Abstract;

namespace Entity;

public class Photo:IEntity
{
    public int id { get; set; }
    public string file_path { get; set; }
    public int advert_id { get; set; }
}