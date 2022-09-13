using Core.BusinessRules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Service.Abstract;

namespace Service.BusinessRules;

public class UserBusinessRules:BusinessRulesBase<User>
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository):base(userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task CheckIfUserWithEmailAlreadyExists(string email)
    {
        var user = await _userRepository.GetByMailAsync(email);
        if (user == null) throw new BusinessException($"User with email: '{email}' already exists!");
    }
    public async Task AssureThatUserExistsByEmail(string email)
    {
        var user = await _userRepository.GetByMailAsync(email);
        if (user == null) throw new BusinessException($"User with email: '{email}' not found!");
    }
}