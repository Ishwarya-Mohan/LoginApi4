using LoginAPI1.ELearnModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewStaffController : ControllerBase
    {
        [HttpPost("AddRequestStaff")]
        public  async Task<IActionResult> AddRequest(NewStaff n)
        {
            using (var db = new ELearnApp1Context())
            {
                db.NewStaffs.Add(n);
                await db.SaveChangesAsync();
                return Ok();
            }
                
        }
    }
}
