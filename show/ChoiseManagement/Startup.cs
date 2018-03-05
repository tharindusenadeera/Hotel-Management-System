using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChoiseManagement.Startup))]
namespace ChoiseManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
