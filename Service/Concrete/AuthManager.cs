using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Service.Abstract;
using Service.Constants;

namespace Service.Concrete;

public class AuthManager:IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    public async Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto)
    {
        string passwordHash, passwordSalt;
        var businessResult = BusinessRules.Run(await IsUserExist(userRegisterDto.Email));
        if (businessResult!=null)
        { 
            return new ErrorDataResult<User>(businessResult.Message);
        }
        HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            email = userRegisterDto.Email,
            first_name = userRegisterDto.FirstName,
            last_name = userRegisterDto.LastName,
            password_hash = passwordHash,
            password_salt = passwordSalt,
            is_active = true
        };
        await _userService.AddAsync(user);
        return new SuccessDataResult<User>(user, Messages.UserRegisteredSuccessfully());
    }

    public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
    {
        var userToCheck = await _userService.GetByMailAsync(userLoginDto.Email);
        if (!userToCheck.Success)
        {
            return new ErrorDataResult<User>(Messages.NotFound("User"));
        }

        if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.password_hash,userToCheck.Data.password_salt))
        {
            return new ErrorDataResult<User>(Messages.LoginFailed());
        }

        return new SuccessDataResult<User>(userToCheck.Data, Messages.UserLoggedInSuccessfully());
    }

    
    private async Task<IResult> IsUserExist(string email)
    {
        var user = await _userService.GetByMailAsync(email);
        if (user.Data!=null)
        {
            return new ErrorResult(Messages.UserAlreadyExists());
        }
        return new SuccessResult();
    }

    public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
    {
        var claims = await _userService.GetClaimsAsync(user.id);
        var accessToken = _tokenHelper.CreateToken(user, claims.Data);
        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated());
    }
}