using System.Web.Mvc;
using CoachAndPlay.DAO;
using System.Web.Routing;
using System.Configuration;

namespace WebCoachAndPlay
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BancoDao.Conexao = ConfigurationManager.ConnectionStrings["CoachAndPlay"].ConnectionString;
        }

        protected void Application_Error()
        {
            Response.Write(Server.GetLastError().Message);
        }
    }
}
