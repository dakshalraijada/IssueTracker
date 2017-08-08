using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IssueTracker.Portal.Attributes
{
    public class NoTenantHandler : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Response.StatusCode == 404)
            {
                context.Result = new ViewResult() { ViewName = "~/Views/Error/Error.cshtml", StatusCode = 404};
                
            }

            base.OnActionExecuting(context);
        }
    }
}
