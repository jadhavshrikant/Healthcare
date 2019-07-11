#region Namespace
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;
[assembly: OwinStartup(typeof(Healthcare.Web.Startup))]
#endregion

namespace Healthcare.Web
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        /// <summary>
        /// ConfigureAuth
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        {
            string tokenExpireTimeInMinute = ConfigurationManager.AppSettings["TokenExpireTimeInMinute"];
            int expireTimeSpan = 10; //default
            int.TryParse(tokenExpireTimeInMinute, out expireTimeSpan);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                SlidingExpiration = true,
                ExpireTimeSpan = new TimeSpan(0, expireTimeSpan, 0),
                LoginPath = new PathString("/Default.aspx")
            });
        }
    }
}