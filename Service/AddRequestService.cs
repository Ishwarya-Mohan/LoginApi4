using LoginAPI1.ELearnModel;
using LoginAPI1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Service
{
    public class AddRequestService:IAddRequestService<NewStaff>
    {

        private readonly IAddRequestRepo<NewStaff> repo;
       

        public AddRequestService(IAddRequestRepo<NewStaff> repo_)
        {
            repo = repo_;
        }
        public void AddRequest(NewStaff n)
        {
            repo.AddRequest(n);

        }
    }
}
