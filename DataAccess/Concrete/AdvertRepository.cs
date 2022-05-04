using System.Data;
using Dapper;
using DataAccess.Abstract;
using Entity;

namespace DataAccess.Concrete;

public class AdvertRepository:IAdvertRepository
{
    private IDbConnection _dbConnection;

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
        var command = "INSERT INTO adverts (name) VALUES(@name) RETURNING id";
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
}