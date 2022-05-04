using Core.Entities.Abstract;

namespace Entity;

public class User:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}