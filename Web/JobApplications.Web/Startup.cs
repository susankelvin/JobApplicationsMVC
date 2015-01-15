using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobApplications.Web.Startup))]
namespace JobApplications.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
