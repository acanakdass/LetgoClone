using Core.Utilities.Results.Abstract;

namespace Core.Business;

public interface IService<T>
{
    Task<IDataResult<IList<T>>> GetAllAsync();

    Task<IDataResult<T>> GetByIdAsync(int id);

    Task<IDataResult<int>> AddAsync(T entity);

    Task<IResult> UpdateAsync(T entity);

    Task<IResult> DeleteAsync(int id);
}