using Core.Business;
using Core.CrossCuttingConcerns.Exceptions;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Core.BusinessRules;

public class BusinessRulesBase<TEntity> where TEntity:class,IEntity
{
    private readonly IDapperEntityRepositoryBase<TEntity> _repository;

    public BusinessRulesBase(IDapperEntityRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }
    public async Task AssureThatEntityExistsById(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null) throw new BusinessException($"{typeof(TEntity).Name} with id:{id} not found!");
    }
}