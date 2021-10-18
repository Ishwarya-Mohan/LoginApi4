using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Repository
{
    public interface IAddContactRepo<Contact>
    {
        public void AddContact(Contact n);
    }
}
