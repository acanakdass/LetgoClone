using AutoMapper;
using Entity;
using Entity.DTOs.Category;

namespace Service.Mappers;

public class CategoryMapper:Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryAddDto>().ReverseMap();
    }
}