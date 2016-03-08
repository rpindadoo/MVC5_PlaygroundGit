﻿using Microsoft.Owin;
using Owin;
using Sample.Web.Hubs;

[assembly: OwinStartup(typeof(Startup))]
namespace Sample.Web.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}