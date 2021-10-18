using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.ELearnModel
{
    public interface IContact<Contact>
    {
        public void AddContact(Contact n);
    }
}
