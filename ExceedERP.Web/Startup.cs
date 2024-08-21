using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExceedERP.Web.Startup))]
namespace ExceedERP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          ConfigureAuth(app);
        }
    }
}
