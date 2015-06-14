using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSW.DataOnion.UserGroupDemo.WebUI.Startup))]
namespace SSW.DataOnion.UserGroupDemo.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
