using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Service
{
    public interface IUserAccountServ<UserAccount>
    {
        public List<UserAccount> GetUserAccountsCredential();
        public void AddUser(UserAccount u);
        public Task<UserAccount> GetDetail(Login u);
        public Task<UserAccount> GetDetailByUsername(string name);


        public Task<List<UserAccount>> GetStudentList();
        public Task<List<UserAccount>> GetStaffList();
        public Task<List<NewStaff>> GetNewReq();
    }
}
