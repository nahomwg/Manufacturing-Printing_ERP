using System.Web.Mvc;

namespace ExceedERP.Web.Areas.CheckPrint
{
    public class CheckPrintAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CheckPrint";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CheckPrint_default",
                "CheckPrint/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}