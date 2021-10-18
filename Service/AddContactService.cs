using LoginAPI1.ELearnModel;
using LoginAPI1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Service
{
    public class AddContactService:IAddContactService<Contact>
    {

        private readonly IAddContactRepo<Contact> repo;


        public AddContactService(IAddContactRepo<Contact> repo_)
        {
            repo = repo_;
        }
        public void AddContact(Contact n)
        {
            repo.AddContact(n);

        }
    }
}
