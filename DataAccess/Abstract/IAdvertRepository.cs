using Core.DataAccess.Abstract;
using Entity;
using Entity.DTOs.Advert;

namespace DataAccess.Abstract;

public interface IAdvertRepository:IRepository<Advert>
{
    Task<IList<AdvertGetPopulatedDto>> GetAllPopulatedAsync();
    Task<IList<AdvertGetPopulatedDto>> GetAllByCategoryPopulatedAsync(int categoryId);

}