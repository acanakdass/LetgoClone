using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Service.Abstract;
using Service.BusinessRules;
using Service.Constants;

namespace Service.Concrete;

public class AuthManager:IAuthService
{
    private IUserService _userService;
    private ITokenHelper _tokenHelper;
    private readonly UserBusinessRules _userBusinessRules;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto)
    {
        await _userBusinessRules.CheckIfUserWithEmailAlreadyExists(userRegisterDto.Email);
        
        string passwordHash, passwordSalt;
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
        await _userBusinessRules.AssureThatUserExistsByEmail(userLoginDto.Email);
        var userToCheck = await _userService.GetByMailAsync(userLoginDto.Email);
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