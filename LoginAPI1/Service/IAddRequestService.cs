using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Service
{
    public interface IAddRequestService<NewStaff>
    {
        public void AddRequest(NewStaff n);
    }
}
