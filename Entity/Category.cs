using Core.Entities.Abstract;

namespace Entity;

public class Category:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}