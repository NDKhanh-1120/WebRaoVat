using System.Web.Mvc;

namespace RaoVar247.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name:"admin_default",
                url:"admin/{controller}/{action}/{id}",
                defaults : new { action = "Index", controller = "Home" ,id = UrlParameter.Optional },
                namespaces: new[] { "RaoVar247.Areas.Admin.Controllers" }
            );
        }
    }
}