using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserRepository:IDapperEntityRepositoryBase<User>,IRepository<User>
{
    Task<List<OperationClaim>> GetClaimsAsync(int userId);
    Task<User> GetByMailAsync(string email);
}