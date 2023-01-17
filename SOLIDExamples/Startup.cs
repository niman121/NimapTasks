using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOLIDExamples.Startup))]
namespace SOLIDExamples
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
