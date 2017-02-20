using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wardrobe2.Startup))]
namespace Wardrobe2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
