using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.ELearnModel
{
    public interface INewStaff<NewStaff>
    {
        public void AddRequest(NewStaff n);
    }
}
