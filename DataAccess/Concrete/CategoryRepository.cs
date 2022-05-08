using System.Data;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Dapper;
using DataAccess.Abstract;
using Entity;

namespace DataAccess.Concrete;

public class CategoryRepository :DapperEntityRepositoryBase<Category>, ICategoryRepository
{
    private readonly IDbConnection _dbConnection;

    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        
    }
    
    public async Task<int> AddAsync(Category entity)
    {
        var command = "INSERT INTO categories (name) VALUES(@name) RETURNING id";
        var id = await _dbConnection.ExecuteScalarAsync<int>(command, entity);
        return id;
    }

    public Task<int> UpdateAsync(Category entity)
    {
        var command = @"UPDATE categories SET name=@name where id=@id";
        return _dbConnection.ExecuteAsync(command, entity);
    }
}