using System;
using Microsoft.Owin;
using Owin;
using StudentSystem;

[assembly: OwinStartupAttribute(typeof(StudentSystem.Startup))]
namespace StudentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
