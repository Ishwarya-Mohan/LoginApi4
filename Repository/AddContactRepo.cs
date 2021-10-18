using LoginAPI1.ELearnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public class AddContactRepo:IAddContactRepo<Contact>
    {
        private readonly IContact<Contact> obj_;

        public AddContactRepo(IContact<Contact> obj_)
        {
            this.obj_ = obj_;
        }
        public void AddContact(Contact n)
        {
            obj_.AddContact(n);

        }
    }
}
