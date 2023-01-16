using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using InventoryManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using System.Threading;

namespace InventoryManagement.Services
{
    public class JwtProvider
    {
        public static string GenerateToken(string username, List<Role> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,username),
                new Claim(ClaimTypes.Name,username)
            };

            roles.ForEach(role =>
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                });

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"])));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(5);

            var token = new JwtSecurityToken(
                Convert.ToString(ConfigurationManager.AppSettings["config:JwtIssuer"]),
                Convert.ToString(ConfigurationManager.AppSettings["config:JwtAudience"]),
                claims,
                expires: expires,
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static ClaimsPrincipal ValidateToken(string token)
        {
            if (token == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Convert.ToString(ConfigurationManager.AppSettings["config:JwtKey"]));

            var validateTokenParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero//token expires 5min later therefore resetting it to zero

            };
            var jwtToken = new JwtSecurityToken();
            try
            {
                tokenHandler.ValidateToken(token, validateTokenParameters, out SecurityToken validatedToken);
                jwtToken = (JwtSecurityToken)validatedToken;
            }
            catch (SecurityTokenException)
            {
                return null;
            }

            if (jwtToken != null)
            {
                var jti = jwtToken.Claims.First(q => q.Type == "jti").Value;
                var userName = jwtToken.Claims.First(q => q.Type == "sub").Value;
            }
            
            var pId = new ClaimsIdentity(jwtToken?.Claims,"jwt", ClaimTypes.Name, ClaimTypes.Role);
            return new ClaimsPrincipal(pId);
            
        }

        public static string GetUserNameFromJwtToken(string token)
        {
            if (token == null) return null;
            try
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var userName = jwtToken.Claims.First(q => q.Type == "sub").Value;
                return userName;
            }
            catch (SecurityTokenException)
            {
                return null;
            }
        }

        public static string[] GetRolesFromJwtToken(string token)
        {
            if (token == null) return null;
            try
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var roles = jwtToken.Claims.Where(q => q.Type == ClaimTypes.Role).ToArray();
                string[] rolesInToken = new string[roles.Count()];
                int counter = 0;
                foreach (var role in roles)
                {
                    rolesInToken[counter] = role.Value;
                    counter++;
                }
                return rolesInToken;
            }
            catch (SecurityTokenException)
            {
                return null;
            }
        }


        public static void AuthenticateRequest(string token, out string userName)
        {
            userName = null;
            try
            {
                var principal = ValidateToken(token);
                userName = GetUserNameFromJwtToken(token);
                HttpContext.Current.User = principal; 
                Thread.CurrentPrincipal = principal;
            }
            catch { }

        }
    }
}