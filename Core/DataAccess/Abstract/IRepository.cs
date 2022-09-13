using System.Linq.Expressions;
using Core.Entities.Abstract;

namespace Core.DataAccess.Abstract;

public interface IRepository<T> where T:class,IEntity
{
    Task<int> AddAsync(T entity);

    Task<int> UpdateAsync(T entity);

}