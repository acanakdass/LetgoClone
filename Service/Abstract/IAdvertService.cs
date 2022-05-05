using Core.Business;
using Core.Utilities.Results.Abstract;
using Entity;
using Entity.DTOs.Advert;

namespace Service.Abstract;

public interface IAdvertService:IService<Advert>
{
    Task<IDataResult<IList<AdvertGetPopulatedDto>>> GetAllPopulatedAsync();
    Task<IDataResult<IList<AdvertGetPopulatedDto>>> GetAllByCategoryPopulatedAsync(int categoryId);
}