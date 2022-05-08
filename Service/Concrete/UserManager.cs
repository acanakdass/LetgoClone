using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Server.IIS.Core;
using Service.Abstract;
using Service.Constants;

namespace Service.Concrete;

public class UserManager : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IOperationClaimService _operationClaimService;
    private const string TableName = "users";

    public UserManager(IUserRepository repository, IOperationClaimService operationClaimService)
    {
        _repository = repository;
        _operationClaimService = operationClaimService;
    }

    public async Task<IDataResult<IList<User>>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync(TableName);
        return new SuccessDataResult<IList<User>>(res);
    }

    public async Task<IDataResult<User>> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(TableName, id);
        if (user != null)
        {
            return new SuccessDataResult<User>(user, Messages.Listed("User"));
        }

        return new ErrorDataResult<User>(null, Messages.NotFound("User"));
    }

    public async Task<IDataResult<int>> AddAsync(User entity)
    {
        var result = await _repository.AddAsync(entity);
        if (result == 1)
            return new SuccessDataResult<int>(Messages.Added("User"));
        return new ErrorDataResult<int>(Messages.FailedAdd("User"));
    }

    public Task<IResult> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        var res = await _repository.DeleteAsync(TableName, id);
        if (res == 1)
            return new SuccessResult(Messages.Deleted("User"));
        return new ErrorResult(Messages.FailedDelete("User"));
    }

    public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(int userId)
    {
        var claims = await _repository.GetClaimsAsync(userId);
        return new SuccessDataResult<List<OperationClaim>>(claims, Messages.Listed("Claims"));
    }

    public async Task<IDataResult<User>> GetByMailAsync(string email)
    {
        var user = await _repository.GetByMailAsync(email);
        return new SuccessDataResult<User>(user, Messages.Listed("User"));
    }

    public async Task<IDataResult<int>> AddRoleToUserAsync(int userId, int operationClaimId)
    {
        IResult businessRulesResult =
            BusinessRules.Run(CheckIfUserExists(userId), CheckIfOperationClaimExists(operationClaimId));
        if (businessRulesResult != null)
            return new ErrorDataResult<int>(0, businessRulesResult.Message);
        var result = await _repository.AddRoleToUserAsync(userId, operationClaimId);
        if (result > 0)
            return new SuccessDataResult<int>(result, Messages.RoleAddedToUser());
        return new ErrorDataResult<int>(0, Messages.ErrorRoleAddedToUser());
    }

    private IResult CheckIfUserExists(int userId)
    {
        var user = _repository.GetByIdAsync(TableName, userId).Result;
        if (user != null)
            return new SuccessResult();
        return new ErrorResult(Messages.NotFound("User"));
    }

    private IResult CheckIfOperationClaimExists(int operationClaimId)
    {
        var claim = _operationClaimService.GetByIdAsync(operationClaimId).Result;
        if (claim.Success)
            return new SuccessResult();
        return new ErrorResult(Messages.NotFound("Operation Claim"));
    }
}