using Business.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var user = HttpContext.Current.User;
            if (user == null || !user.Identity.IsAuthenticated) return;

            var auth = new AuthMiddleware();
            var principal = auth.GetPrincipal(user.Identity.Name);
            if (principal != null)
            {
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}
