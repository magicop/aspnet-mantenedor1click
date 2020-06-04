using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMantenedorOneClick.Startup))]
namespace WebMantenedorOneClick
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
