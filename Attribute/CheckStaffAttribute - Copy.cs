using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebTravel.Attribute
{
    public class CheckStaffAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (string.IsNullOrEmpty(session.GetString("Username")) && session.GetString("Role") != "NhanVien")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    {"area", "Staff" },
                    { "controller", "Account" },
                    { "action", "Login" }
                    });
            }
            base.OnActionExecuting(context);
        }
    }

}
