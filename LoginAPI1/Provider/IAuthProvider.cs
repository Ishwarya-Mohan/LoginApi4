using LoginAPI1.ELearnModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Provider
{
    public interface IAuthProvider<UserAccount>
    {
        public string GenerateJSONWebToken(ELearnModel.UserAccount u, IConfiguration _config);
        public dynamic Authentication(ELearnModel.Login login);
       // UserAccount Authentication(Login login);
    }
}
