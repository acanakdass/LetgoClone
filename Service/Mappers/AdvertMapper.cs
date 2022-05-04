using AutoMapper;
using Entity;
using Entity.DTOs.Advert;

namespace Service.Mappers;
public class AdvertMapper:Profile
{
    public AdvertMapper()
    {
        CreateMap<Advert, AdvertAddDto>().ReverseMap();
        CreateMap<Advert, AdvertGetDto>().ReverseMap();
    }
}