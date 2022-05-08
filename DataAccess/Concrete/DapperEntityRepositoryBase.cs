using System.Data;
using Core.Entities.Abstract;
using Core.Utilities.Ioc;
using Dapper;
using DataAccess.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete;

public class DapperEntityRepositoryBase<TEntity> : IDapperEntityRepositoryBase<TEntity>
    where TEntity : class, IEntity
{
    private readonly IDbConnection _dbConnection = ServiceTool.ServiceProvider.GetService<IDbConnection>();

    public async Task<List<TEntity>> GetAllAsync(string tableName)
    {
        var query = $"SELECT * FROM {tableName}";
        var res = await _dbConnection.QueryAsync<TEntity>(query);
        return res.ToList();
    }

    public async Task<TEntity> GetByIdAsync(string tableName, int id)
    {
        var query = $"SELECT * FROM {tableName} WHERE id={id}";
        var result = await _dbConnection.QueryAsync<TEntity>(query);
        return result.FirstOrDefault();
    }

    public async Task<int> DeleteAsync(string tableName, int id)
    {
        var command = $"DELETE FROM {tableName} WHERE id={id}";
        return await _dbConnection.ExecuteAsync(command);
    }
}