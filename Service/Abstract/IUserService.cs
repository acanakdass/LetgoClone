using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Service.Abstract;

public interface IUserService:IService<User>
{
    Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(int userId);
    Task<IDataResult<User>> GetByMailAsync(string email);
    Task<IDataResult<int>> AddRoleToUserAsync(int userId,int operationClaimId);
}