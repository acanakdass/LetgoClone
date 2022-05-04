using System.Data;
using AutoMapper;
using Service.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity;
using Service.Constants;

namespace Service.Concrete;

public class AdvertManager : IAdvertService
{

    private readonly IAdvertRepository _repository;
    private readonly ICategoryService _categoryService;
    public AdvertManager(IAdvertRepository repository, ICategoryService categoryService)
    {
        _repository = repository;
        _categoryService = categoryService;
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
        var result = await _repository.AddAsync(entity);
        if (result >= 1)
            return new SuccessDataResult<int>(result, Messages.Added("Advert"));
        return new ErrorDataResult<int>(0, "Error while adding advert");
    }

    public Task<IResult> UpdateAsync(Advert entity)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}