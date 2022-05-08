using System.Data;
using Core.Entities.Concrete;
using Dapper;
using DataAccess.Abstract;

namespace DataAccess.Concrete;

public class OperationClaimRepository:DapperEntityRepositoryBase<OperationClaim>,IOperationClaimRepository
{
    private readonly IDbConnection _dbConnection;

    public OperationClaimRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> AddAsync(OperationClaim entity)
    {
        var command = $"INSERT INTO operation_claims(name) VALUES('{entity.name}')";
        return await _dbConnection.ExecuteAsync(command);
    }

    public async Task<int> UpdateAsync(OperationClaim entity)
    {
        var command = $"UPDATE operation_claims SET name='{entity.name}' WHERE id={entity.id}";
        return await _dbConnection.ExecuteAsync(command);
    }
}