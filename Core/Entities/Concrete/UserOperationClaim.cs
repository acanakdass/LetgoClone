using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class UserOperationClaim:IEntity
{
    public int id { get; set; } 
    public int user_id { get; set; }
    public int operation_claim_id { get; set; }
} 