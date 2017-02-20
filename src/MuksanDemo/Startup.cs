using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MuksanDemo.Startup))]
namespace MuksanDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
