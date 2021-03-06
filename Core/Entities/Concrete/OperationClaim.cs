using Core.Attributes;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

[TableName("operation_claims")]
public class OperationClaim:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}