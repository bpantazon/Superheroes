using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Superheroes.Startup))]
namespace Superheroes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
