using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryAjaxInAsp.NetMVC.Startup))]
namespace JQueryAjaxInAsp.NetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
