using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(medlab.Startup))]
namespace medlab
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
