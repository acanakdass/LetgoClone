using Core.Entities.Abstract;

namespace DataAccess.Abstract;

public interface IDapperEntityRepositoryBase<TEntity> 
    where TEntity:class,IEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<int> DeleteAsync(int id);
}