using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public interface ICredentialRepo
    {
        public List<UserAccount> GetCredentials();
    }
}
