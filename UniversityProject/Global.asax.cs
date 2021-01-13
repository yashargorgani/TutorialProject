using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UniversityProject.DAL;

namespace UniversityProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                UniversityDbContext db = new UniversityDbContext();

                var user = db.UserAccount.FirstOrDefault(x => x.EmailAdress == User.Identity.Name);

                GenericPrincipal princpal = new GenericPrincipal(User.Identity, new string[] { user.Role.Caption });

                HttpContext.Current.User = princpal;
            }
        }
    }
}
