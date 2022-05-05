using System.Data;
using AutoMapper;
using Service.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity;
using Service.Constants;

namespace Service.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IDataResult<IList<Category>>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return new SuccessDataResult<IList<Category>>(result);
    }

    public async Task<IDataResult<Category>> GetByIdAsync(int id)
    {
        var result = await _categoryRepository.GetByIdAsync(id);
        if (result == null)
            return new ErrorDataResult<Category>(null, "Category Not Found");
        return new SuccessDataResult<Category>(result, Messages.Listed("Category"));
    }

    public async Task<IDataResult<int>> AddAsync(Category entity)
    {
        var result = await _categoryRepository.AddAsync(entity);
        if (result >= 1)
            return new SuccessDataResult<int>(result, Messages.Added("Category"));
        return new ErrorDataResult<int>(0, "Error while adding category");
    }

    public async Task<IResult> UpdateAsync(Category entity)
    {
        var result = await _categoryRepository.UpdateAsync(entity);
        if (result != 0)
        {
            return new SuccessResult(Messages.Updated("Category"));
        }
        return new ErrorResult(Messages.FailedUpdate("Category"));
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        var result = await _categoryRepository.DeleteAsync(id);
        if (result != 0)
        {
            return new SuccessResult(Messages.Deleted("Category"));
        }
        return new ErrorResult(Messages.FailedDelete("Category"));
    }
}