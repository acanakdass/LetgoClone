using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace Service.Abstract;

public interface IAuthService
{
    Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto);
    Task<IDataResult<User>> Login(UserLoginDto userLoginDto);
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
}