using Core.CrossCuttingConcerns.Exceptions;
using Service.Abstract;

namespace Service.BusinessRules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimService _operationClaimService;

    public OperationClaimBusinessRules(IOperationClaimService operationClaimService)
    {
        _operationClaimService = operationClaimService;
    }

    public async Task AssureThatOperationClaimExistsById(int id)
    {
        var user = await _operationClaimService.GetByIdAsync(id);
        if (user.Data == null) throw new BusinessException($"Operation claim with id : {id} not found!");
    }
}