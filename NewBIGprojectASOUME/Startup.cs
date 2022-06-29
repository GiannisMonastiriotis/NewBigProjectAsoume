using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewBIGprojectASOUME.Startup))]

namespace NewBIGprojectASOUME
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}