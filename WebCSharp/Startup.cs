using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebCSharp.StartupOwin))]

namespace WebCSharp
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
