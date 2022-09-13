using Entity.DTOs.Category;
using FluentValidation;

namespace Service.Validators.CategoryValidators;

public class CategoryCreateValidator:AbstractValidator<CategoryAddDto>
{
    public CategoryCreateValidator()
    {
        RuleFor(x => x.name).NotEmpty().MinimumLength(2);
    }
}