using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RolesDemo.Startup))]
namespace RolesDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
           
        }
    }
}
