using Core.Attributes;
using Core.Entities.Abstract;

namespace Entity;

[TableName("statuses")]
public class Status:IEntity
{
    public int id { get; set; }
    public string name { get; set; }
}