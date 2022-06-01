using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhamTienMinh_BigSchool.Startup))]
namespace PhamTienMinh_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
