using LoginAPI1.ELearnModel;
using LoginAPI1.Repository;
using LoginAPI1.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI1.Provider
{
    public class AuthProvider:IAuthProvider<UserAccount>
    {
        public readonly IUserAccountServ<UserAccount> obj;
        public AuthProvider(IUserAccountServ<UserAccount> obj)
        {
            this.obj = obj;
        }
        public dynamic Authentication(Login login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                UserAccount user = null;
                List<UserAccount> users = obj.GetUserAccountsCredential();
                if (users == null)
                    return null;
                else
                {
                    if(users.Any(u=>u.Username==login.Username && u.Password == login.Password))
                    {
                        using (var db = new ELearnApp1Context())
                
                        user = (from i in db.UserAccounts where i.Username == login.Username && i.Password == login.Password select i).FirstOrDefault();
                
                    }
                }
                //using (var db = new ELearnApp1Context())
                //{
                //    user = (from i in db.UserAccounts where i.Username == login.Username && i.Password == login.Password select i).FirstOrDefault();
                //}
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string GenerateJSONWebToken(UserAccount u, IConfiguration _config)
        {
            if (u == null)
            {
                return null;
            }
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
