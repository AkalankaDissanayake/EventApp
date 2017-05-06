using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.UI.Startup))]
namespace App.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
