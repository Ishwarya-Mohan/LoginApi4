using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public class UserAccountRepo:IUserAccountRepo<UserAccount>
    {
        private readonly IUserAccount<UserAccount> obj_;
        UserAccount us = new UserAccount();
        public UserAccountRepo(IUserAccount<UserAccount> obj_)
        {
            this.obj_ = obj_;
        }
        public List<UserAccount> GetUserAccountsCredential()
        {
            return obj_.GetUserAccountsCredential();
        }
        public void AddUser(UserAccount u)
        {
            obj_.AddUser(u);
            
        }

        public async Task<UserAccount> GetDetail(Login u)
        {
            return await obj_.GetDetail(u);
        }

        public async Task<UserAccount> GetDetailByUsername(string name)
        {
            return await obj_.GetDetailByUsername(name);
        }

        public async Task<List<UserAccount>> GetStudentList()
        {
            return await obj_.GetStaffList();
        }

        public async Task<List<UserAccount>> GetStaffList()
        {
            return await obj_.GetStudentList();
        }

        public async Task<List<NewStaff>> GetNewReq()
        {
            return await obj_.GetNewReq();
        }

       
    }
}
