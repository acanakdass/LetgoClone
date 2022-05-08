using System.Data;
using Core.Entities.Concrete;
using Dapper;
using DataAccess.Abstract;

namespace DataAccess.Concrete;

public class UserRepository : DapperEntityRepositoryBase<User>, IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> AddAsync(User entity)
    {
        var query = @$"INSERT INTO users(first_name,last_name,email,password_hash,password_salt,is_active) VALUES('{entity.first_name}','{entity.last_name}','{entity.email}','{entity.password_hash}','{entity.password_salt}','{entity.is_active}') RETURNING id";
        var res = await _dbConnection.ExecuteAsync(query);
        return res;
    }

    public Task<int> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<OperationClaim>> GetClaimsAsync(int userId)
    {
        var query = $@"select  oc.id , oc.name from users u
            inner join user_operation_claims uoc on uoc.user_id = u.id
            inner join operation_claims oc on oc.id = uoc.operation_claim_id
            where u.id={userId}";
        var claims = await _dbConnection.QueryAsync<OperationClaim>(query);
        return claims.ToList();
    }

    public async Task<User> GetByMailAsync(string email)
    {
        var query = $"SELECT * FROM users WHERE email='{email}'";
        var res = await _dbConnection.QueryAsync<User>(query);
        return res.FirstOrDefault();
    }

    public async Task<int> AddRoleToUserAsync(int userId, int roleId)
    {
        var comand = $"INSERT INTO user_operation_claims(user_id,operation_claim_id) VALUES ({userId},{roleId})";
        return await _dbConnection.ExecuteAsync(comand);
        
    }
}