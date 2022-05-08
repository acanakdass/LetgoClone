using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Service.Abstract;
using Service.Constants;

namespace Service.Concrete;

public class OperationClaimManager : IOperationClaimService
{
    private readonly IOperationClaimRepository _repository;
    private const string TableName = "operation_claims";

    public OperationClaimManager(IOperationClaimRepository repository)
    {
        _repository = repository;
    }

    public async Task<IDataResult<IList<OperationClaim>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync(TableName);
        return new SuccessDataResult<IList<OperationClaim>>(result, Messages.Listed("Operation claims"));
    }

    public async Task<IDataResult<OperationClaim>> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(TableName, id);
        if (result != null)
            return new SuccessDataResult<OperationClaim>(result, Messages.Listed("Operation Claim"));
        return new ErrorDataResult<OperationClaim>(null, Messages.NotFound("Operation Claim"));
    }

    public async Task<IDataResult<int>> AddAsync(OperationClaim entity)
    {
        var result = await _repository.AddAsync(entity);
        if (result > 0)
            return new SuccessDataResult<int>(result, Messages.Added("Operation Claim"));
        return new ErrorDataResult<int>(0, Messages.FailedAdd("Operation Claim"));
    }

    public Task<IResult> UpdateAsync(OperationClaim entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        var result = await _repository.DeleteAsync(TableName,id);
        if (result > 0)
            return new SuccessResult(Messages.Deleted("Operation Claim"));
        return new ErrorResult(Messages.FailedDelete("Operation Claim"));
    }
}