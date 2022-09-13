using Core.BusinessRules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity;
using Service.Abstract;

namespace Service.BusinessRules;

public class CategoryBusinessRules:BusinessRulesBase<Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository):base(categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task AssureThatCategoryWithNameNotExists(string name)
    {
        var user = await _categoryRepository.GetByNameAsync(name);
        if (user != null) throw new BusinessException($"Category with name: {name} already exists!");
    }
}