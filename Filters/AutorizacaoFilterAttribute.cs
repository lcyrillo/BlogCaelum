using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

public class AutorizacaoFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var usuario = filterContext.HttpContext.Session.GetString("usuario");

        if(usuario == null)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new {
                        area = "",
                        controller = "Usuario",
                        action = "Login"
                    }));
        }
    }
}