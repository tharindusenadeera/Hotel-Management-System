using System.Web.Mvc;

namespace ChoiseManagement.Areas.Commen
{
    public class CommenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Commen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Commen_default",
                "Commen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}