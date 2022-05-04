namespace Core.Entities.Concrete;

public class EntityBase
{
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    public virtual int CreatedById { get; set; }
    public virtual int UpdatedById { get; set; }
    public virtual string Description { get; set; }
    public virtual bool IsDeleted { get; set; } = false;
}