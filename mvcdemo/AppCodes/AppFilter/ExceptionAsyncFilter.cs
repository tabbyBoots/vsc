using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvcdemo.Filters
{
    public class ExceptionAsyncFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            return Task.CompletedTask;
        }
    }
}
