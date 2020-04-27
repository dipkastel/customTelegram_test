using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Database.Config;
using Database.Models;

namespace alphadinCore.Services.Helper
{
    public class AuthHelper
    {
        private const int TOKEN_LIFE_TIME = 8;
        public AuthHelper() {
        }
        public User AuthenticateUser(User login,DbContextModel db)
        {
            User thisUser = db.Users.Include(o=>o.Role).Where(p => p.MobileNumber == login.MobileNumber).FirstOrDefault();

            return thisUser;

        }

        public void GenerateJSONWebToken(User user,IConfiguration config,DbContextModel db,int status)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            IdentityOptions _options = new IdentityOptions();
            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.Sub,user.MobileNumber),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(_options.ClaimsIdentity.RoleClaimType,user.Role.Name)


            };
            var authToken = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(TOKEN_LIFE_TIME),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(authToken);

            db.UserTokens.Add(new UserToken { User = user, CreateDate = DateTime.Now, ExpiteDate = DateTime.Now.AddHours(TOKEN_LIFE_TIME), Status = status, Token = encodetoken });
            db.SaveChanges();

        }

    }
}
