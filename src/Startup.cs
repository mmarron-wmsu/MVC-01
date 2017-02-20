using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dudungcharing.Startup))]
namespace dudungcharing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
