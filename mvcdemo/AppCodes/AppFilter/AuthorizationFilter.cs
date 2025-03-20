using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvcdemo.Filters
{

    [AttributeUsage(AttributeTargets.All)]
    public class AuthorizationFilter : Attribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var controllerName = context.RouteData.Values["Controller"];
            var actionName = context.RouteData.Values["Action"];

            // 判斷使用者是否登入            
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // 沒有登入 HttpStatusCode = 401 尚未授權                
                
                context.Result = new UnauthorizedResult();

                //返回登入頁 (User/Login)
                context.Result = new RedirectToRouteResult
                (
                    new RouteValueDictionary
                    (
                        new
                        {
                            area = "",
                            controller = "User",
                            action = "Login"
                        }
                    )
                );
            }
        }
    }
}
