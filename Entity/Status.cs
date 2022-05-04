using Core.Entities.Abstract;

namespace Entity;

public class Status:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}