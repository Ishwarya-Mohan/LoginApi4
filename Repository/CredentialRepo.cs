using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public class CredentialRepo:ICredentialRepo
    {
        public readonly ELearnApp1Context db;
        public List<UserAccount> GetCredentials()
        {
            List<UserAccount> u = new List<UserAccount>();
            u = db.UserAccounts.ToList();
            return u;
        }
    }
}
