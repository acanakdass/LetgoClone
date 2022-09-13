using Core.BusinessRules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity;
using Service.Abstract;

namespace Service.BusinessRules;

public class AdvertBusinessRules:BusinessRulesBase<Advert>
{
    private readonly IAdvertRepository _repository;

    public AdvertBusinessRules(IAdvertRepository repository) : base(repository)
    {
        _repository = repository;
    }
}