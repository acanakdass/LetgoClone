using System.Data;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Dapper;
using DataAccess.Abstract;
using Entity;

namespace DataAccess.Concrete;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _dbConnection;

    public CategoryRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        var query = "SELECT * FROM categories";
        var users = await _dbConnection.QueryAsync<Category>(query);
        return users.ToList();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var query = $"SELECT * FROM categories WHERE id={id}";
        var result = await _dbConnection.QueryAsync<Category>(query);
        return result.FirstOrDefault();
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

    public async Task<int> DeleteAsync(int id)
    {
        var command = $"DELETE FROM categories WHERE id={id}";
        return await _dbConnection.ExecuteAsync(command);
    }
}