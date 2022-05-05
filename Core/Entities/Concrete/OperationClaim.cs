using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class OperationClaim:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}