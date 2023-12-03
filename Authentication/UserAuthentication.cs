using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pass_It_Out.Authentication
{
    public class UserAuthentication : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (String.IsNullOrEmpty( context.HttpContext.Session.GetString("UserId")))
            {
                context.Result = new RedirectToActionResult("UserLogin", "User", null);
            }
        }
    }
}
