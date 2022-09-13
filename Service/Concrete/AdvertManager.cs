using Service.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity;
using Entity.DTOs.Advert;
using Microsoft.AspNetCore.Http;
using Service.Aspects.Security;
using Service.BusinessRules;
using Service.Constants;
using IResult = Core.Utilities.Results.Abstract.IResult;

namespace Service.Concrete;

public class AdvertManager : IAdvertService
{
    private readonly IAdvertRepository _repository;
    private readonly ICategoryService _categoryService;
    private readonly AdvertBusinessRules _advertBusinessRules;
    public AdvertManager(IAdvertRepository repository, ICategoryService categoryService, AdvertBusinessRules advertBusinessRules)
    {
        _repository = repository;
        _categoryService = categoryService;
        _advertBusinessRules = advertBusinessRules;
    }

    public async Task<IDataResult<IList<Advert>>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return new SuccessDataResult<IList<Advert>>(result);
    }

    public async Task<IDataResult<Advert>> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        if (result == null)
            return new ErrorDataResult<Advert>(null, "Advert Not Found");
        return new SuccessDataResult<Advert>(result, Messages.Listed("Advert"));
    }

    public async Task<IDataResult<int>> AddAsync(Advert entity)
    {
        entity.created_date = DateTime.Now;
        var result = await _repository.AddAsync(entity);
        if (result >= 1)
            return new SuccessDataResult<int>(result, Messages.Added("Advert"));
        return new ErrorDataResult<int>(0, "Error while adding advert");
    }

    public async Task<IResult> UpdateAsync(Advert entity)
    {
        await _advertBusinessRules.AssureThatEntityExistsById(entity.id);
        throw new NotImplementedException();
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        //business rules
        await _advertBusinessRules.AssureThatEntityExistsById(id);
        
        var res = await _repository.DeleteAsync(id);
        if (res > 0)
            return new SuccessResult(Messages.Deleted("Advert"));
        return new ErrorResult(Messages.FailedDelete("Advert"));
    }

    public async Task<IDataResult<IList<AdvertGetPopulatedDto>>> GetAllPopulatedAsync()
    {
        var res = await _repository.GetAllPopulatedAsync();
        return new SuccessDataResult<IList<AdvertGetPopulatedDto>>(res, Messages.Listed("Adverts"));
    }

    public async Task<IDataResult<IList<AdvertGetPopulatedDto>>> GetAllByCategoryPopulatedAsync(int categoryId)
    {
        var res = await _repository.GetAllByCategoryPopulatedAsync(categoryId);
        return new SuccessDataResult<IList<AdvertGetPopulatedDto>>(res, Messages.Listed("Adverts"));
    }
}