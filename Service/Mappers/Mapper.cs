using AutoMapper;
using Entity;
using Entity.Dtos;

namespace Service.Mappers;

public class Mapper:Profile
{
    public Mapper()
    {
        CreateMap<Category, CategoryAddDto>().ReverseMap();
    }
}