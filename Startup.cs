using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(InventoryManagement.Startup))]
namespace InventoryManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = "http://localhost:58218/Account/login";
            var key = Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"]));
            var audienceId = ConfigurationManager.AppSettings["config:JwtAudience"];

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "http://localhost:58218/Account/login",
                    ValidAudience = "http://localhost:58218/Account/login"
                    //ClockSkew = TimeSpan.Zero
                },
                AllowedAudiences = new[] { audienceId },
                IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                {
                    new SymmetricKeyIssuerSecurityKeyProvider(issuer,ConfigurationManager.AppSettings["config:JwtKey"])
                }
            });
        }
    }
}
