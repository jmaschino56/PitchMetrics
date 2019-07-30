using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PitchMetrics.Startup))]
namespace PitchMetrics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}