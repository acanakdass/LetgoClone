using System.Linq.Expressions;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract;

public interface IRepository<T> where T:class,IEntity
{
    // Task<IList<T>> GetAllAsync(string tableName);
    // Task<T> GetByIdAsync(string tableName,int id);
    //
    // Task<int> DeleteAsync(string tableName,int id);
    Task<int> AddAsync(T entity);

    Task<int> UpdateAsync(T entity);

}