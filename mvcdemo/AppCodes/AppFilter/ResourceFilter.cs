using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvcdemo.Filters
{
    public class ResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }
    }
}
