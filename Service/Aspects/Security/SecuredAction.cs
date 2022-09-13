using System.Net;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Extensions;
using Core.Utilities.Ioc;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Constants;

namespace Service.Aspects.Security;

public class SecuredAction : ActionFilterAttribute
{
    private readonly string[] _roles;

    public SecuredAction(string claims)
    {
        _roles = claims.Split(",");
        //_userService = ServiceTool.ServiceProvider.GetService<IUserService>();
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var roleClaims = context.HttpContext.User.ClaimRoles();
        foreach (var role in _roles)
        {
            if (roleClaims.Contains(role))
            {
                return;
            }
        }

        throw new AuthorizationException(Messages.AuthorizationFailed());
        context.Result = new ObjectResult(new ErrorResult(Messages.AuthorizationFailed())) {StatusCode = 401};
    }
}