using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Service.Abstract;
using Service.Constants;

namespace Service.Concrete;

public class UserManager : IUserService
{
    private readonly IUserRepository _repository;
    private readonly string tableName = "users";

    public UserManager(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IDataResult<IList<User>>> GetAllAsync()
    {
        var res = await _repository.GetAllAsync(tableName);
        return new SuccessDataResult<IList<User>>(res);
    }

    public Task<IDataResult<User>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
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
        var res = await _repository.DeleteAsync(tableName, id);
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
}