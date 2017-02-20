using System.Web.Mvc;

namespace dudungcharing.Areas.security
{
    public class securityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "security";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "security_default",
                "security/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}