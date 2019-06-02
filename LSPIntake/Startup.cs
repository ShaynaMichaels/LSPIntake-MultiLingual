using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LSPIntake.Startup))]
namespace LSPIntake
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
