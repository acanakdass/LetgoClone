using Core.Business;
using Core.DataAccess.Abstract;
using Entity;

namespace DataAccess.Abstract;

public interface ICategoryRepository:IDapperEntityRepositoryBase<Category>,IRepository<Category>
{
}