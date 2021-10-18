using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public class AddRequestRepo:IAddRequestRepo<NewStaff>
    {

        private readonly INewStaff<NewStaff> obj_;
       
        public AddRequestRepo(INewStaff<NewStaff> obj_)
        {
            this.obj_ = obj_;
        }
        public void AddRequest(NewStaff n)
        {
            obj_.AddRequest(n);

        }
    }
}
