using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvcdemo.Filters
{
    public class ActionAsyncFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

            await next();

            await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}
