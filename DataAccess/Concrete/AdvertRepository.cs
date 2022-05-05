using System.Data;
using Dapper;
using DataAccess.Abstract;
using Entity;
using Entity.DTOs.Advert;

namespace DataAccess.Concrete;

public class AdvertRepository : IAdvertRepository
{
    private readonly IDbConnection _dbConnection;

    public AdvertRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IList<Advert>> GetAllAsync()
    {
        var query = "SELECT * FROM adverts";
        var adverts = await _dbConnection.QueryAsync<Advert>(query);
        return adverts.ToList();
    }

    public async Task<Advert> GetByIdAsync(int id)
    {
        var query = $"SELECT * FROM adverts WHERE id={id}";
        var result = await _dbConnection.QueryAsync<Advert>(query);
        return result.FirstOrDefault();
    }

    public async Task<int> AddAsync(Advert entity)
    {
        var command =
            @"INSERT INTO adverts (title,description,user_id,price,
                status_id,is_new,category_id,is_tradable,is_active,created_date,is_sold)
                VALUES(@title,@description,@user_id,@price,
                @status_id,@is_new,@category_id,@is_tradable,
                @is_active,@created_date,@is_sold) RETURNING id";
        var id = await _dbConnection.ExecuteScalarAsync<int>(command, entity);
        return id;
    }

    public Task<int> UpdateAsync(Advert entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    //*****************************************************\\
    public async Task<IList<AdvertGetPopulatedDto>> GetAllPopulatedAsync()
    {
        var sql =
            @"select a.id, title, description, price, is_new, is_active, is_sold, is_tradable, a.created_date,
                a.category_id, c.id, c.name,
                a.status_id, s.id ,s.name,
                a.user_id, u.id ,u.name,u.email
                from adverts a
                inner join categories c on a.category_id = c.id
                inner join statuses s on a.status_id = s.id
                inner join users u on a.user_id = u.id";

        var adverts =
            await _dbConnection.QueryAsync<AdvertGetPopulatedDto, Category, Status, User, AdvertGetPopulatedDto>(
                sql, (advert, category, status, user) =>
                {
                    advert.Category = category;
                    advert.Status = status;
                    advert.User = user;
                    return advert;
                }, splitOn: "category_id, status_id, user_id");
        return adverts.ToList();
    }

    public async Task<IList<AdvertGetPopulatedDto>> GetAllByCategoryPopulatedAsync(int categoryId)
    {
        var sql =
            $@"select a.id, title, description, price, is_new, is_active, is_sold, is_tradable, a.created_date,
                a.category_id, c.id, c.name,
                a.status_id, s.id ,s.name,
                a.user_id, u.id ,u.name,u.email
                from adverts a
                inner join categories c on a.category_id = c.id
                inner join statuses s on a.status_id = s.id
                inner join users u on a.user_id = u.id
                WHERE category_id={categoryId}";

        var adverts =
            await _dbConnection.QueryAsync<AdvertGetPopulatedDto, Category, Status, User, AdvertGetPopulatedDto>(
                sql, (advert, category, status, user) =>
                {
                    advert.Category = category;
                    advert.Status = status;
                    advert.User = user;
                    return advert;
                }, splitOn: "category_id, status_id, user_id");
        return adverts.ToList();
    }
}