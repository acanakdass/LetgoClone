using Core.DataAccess.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IOperationClaimRepository:IDapperEntityRepositoryBase<OperationClaim>,IRepository<OperationClaim>
{
    
}