using LoginAPI1.ELearnModel;
using LoginAPI1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Service
{
    public class UserAccountServ: IUserAccountServ<UserAccount>
    {
        private readonly IUserAccountRepo<UserAccount> repo;
        public UserAccount us = new UserAccount();

        public UserAccountServ(IUserAccountRepo<UserAccount> repo_)
        {
            repo = repo_;
        }
        public List<UserAccount> GetUserAccountsCredential()
        {
            return repo.GetUserAccountsCredential();
        }
        
        public void AddUser(UserAccount u)
        {
            repo.AddUser(u);
        }

        public async Task<UserAccount> GetDetail(Login u)
        {
              return await repo.GetDetail(u);
            
        }

        public async Task<UserAccount> GetDetailByUsername(string name)
        {
            return await repo.GetDetailByUsername(name);
        }

        public async Task<List<UserAccount>> GetStudentList()
        {
            return await repo.GetStudentList();
        }

        public async  Task<List<UserAccount>> GetStaffList()
        {
            return await repo.GetStaffList();
        }

        public async Task<List<NewStaff>> GetNewReq()
        {
            return await repo.GetNewReq();
        }
    }
}
