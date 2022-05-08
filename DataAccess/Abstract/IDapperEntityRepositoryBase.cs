using Core.Entities.Abstract;

namespace DataAccess.Abstract;

public interface IDapperEntityRepositoryBase<TEntity> 
    where TEntity:class,IEntity
{
    Task<List<TEntity>> GetAllAsync(string tableName);
    Task<TEntity> GetByIdAsync(string tableName,int id);
    Task<int> DeleteAsync(string tableName,int id);
}