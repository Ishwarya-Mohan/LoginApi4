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
    public class ContactController : ControllerBase
    {
        [HttpPost("Contact")]
        public async Task<IActionResult> AddContact(Contact n)
        {
            using (var db = new ELearnApp1Context())
            {
                db.Contacts.Add(n);
                await db.SaveChangesAsync();
                return Ok();
            }

        }
    }
}
