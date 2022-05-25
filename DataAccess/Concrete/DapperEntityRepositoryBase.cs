using System.Data;
using System.Reflection;
using Core.Entities.Abstract;
using Core.Helpers;
using Core.Utilities.Ioc;
using Dapper;
using DataAccess.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete;

public class DapperEntityRepositoryBase<TEntity> : IDapperEntityRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
{
    private readonly IDbConnection _dbConnection = ServiceTool.ServiceProvider.GetService<IDbConnection>();
    private readonly string tableName = AttributeHelpers.GetTableName<TEntity>();

    public async Task<List<TEntity>> GetAllAsync()
    {
        var query = $"SELECT * FROM {tableName}";
        var res = await _dbConnection.QueryAsync<TEntity>(query);
        return res.ToList();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var query = $"SELECT * FROM {tableName} WHERE id={id}";
        var result = await _dbConnection.QueryAsync<TEntity>(query);
        return result.FirstOrDefault();
    }

    public async Task<int> DeleteAsync( int id)
    {
        var command = $"DELETE FROM {tableName} WHERE id={id}";
        return await _dbConnection.ExecuteAsync(command);
    }
}