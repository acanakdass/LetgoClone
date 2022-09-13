using Core.Business;
using Core.DataAccess.Abstract;
using Entity;

namespace DataAccess.Abstract;

public interface ICategoryRepository:IRepository<Category>,IDapperEntityRepositoryBase<Category>
{
    Task<Category> GetByNameAsync(string name);

}