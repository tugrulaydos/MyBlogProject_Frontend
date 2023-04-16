using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBlogProject_Frontend.Areas.Admin.AttributeFilters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SessionAttribute:ActionFilterAttribute
    {
        private readonly string _sessionKey;
        private readonly string _redirectUrl;

        public SessionAttribute(string key, string controllerName, string actionName)
        {
            _sessionKey = key;
            _redirectUrl = $"/admin/{controllerName}/{actionName}";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessionValue = context.HttpContext.Session.GetString( _sessionKey);

            if(string.IsNullOrEmpty(sessionValue) )
            {
                context.Result = new RedirectResult(_redirectUrl);
            }

           
        }

    }
}
