using AutoMapper;

using LoginAPI1.ELearnModel;
using LoginAPI1.Provider;
using LoginAPI1.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration config;
        private readonly IAuthProvider<UserAccount> ap;
        private readonly IUserAccountServ<UserAccount> uas;
        public string tokenString = "";
       // private readonly IMapper _mapper;
        public AuthController(IConfiguration config, IAuthProvider<UserAccount> ap)
        {
           
            this.config = config;
            this.ap = ap;
        }
        public AuthController(IUserAccountServ<UserAccount> _uas)
        {
            uas = _uas;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login) {
            //_log4net.Info(" Http Post request");
            //var userFromRepo = await _ap.Login(login.Username.ToLower(), login.Password);
            if (login == null)
            {
                return BadRequest();
            }
            try
            {

                IActionResult response = Unauthorized();
                UserAccount user = ap.Authentication(login);
                //authenticatin the user first
              //  var model = _mapper.Map<UserLoginDto>(user);

                if (user != null)
                {
                    tokenString = ap.GenerateJSONWebToken(user, config);        //generating token only if the user is authenticated
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Append("Valid", tokenString, cookie);
                    response = Ok(tokenString);
                    


                }

                return response;
            }
            catch (Exception e)
            {
               // _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }

        }
        [HttpGet("CheckAuthentication")]
        [Authorize]
        [AllowAnonymous]
        public IActionResult CheckAuthentication()
        {
            if (Request.Cookies["valid"] != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> AddUser(UserAccount u)
        {
            UserAccount ua = new UserAccount();
            using (var db = new ELearnApp1Context())
            {
                db.UserAccounts.Add(u);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost("UserDetail")]
        public async Task<ActionResult<UserAccount>> GetDetail(Login u)
        {

            using (var db = new ELearnApp1Context())
            {
                UserAccount ua = await (from i in db.UserAccounts where i.Username == u.Username && i.Password == u.Password select i).FirstOrDefaultAsync();
                return Ok(ua);
            }
        }
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<UserAccount>> GetDetailByUsername(string name)
        {
            using (var db = new ELearnApp1Context())
            {
                UserAccount ua = await (from i in db.UserAccounts where i.Username == name select i).FirstOrDefaultAsync();
                return Ok(ua);
            }
        }
        [HttpGet("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db = new ELearnApp1Context())
            {
                ui = await (from i in db.UserAccounts where i.Role == "Student" select i).ToListAsync();
                return Ok(ui);
            }
        }
        [HttpGet("GetStaffList")]
        public async Task<IActionResult> GetStaffList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db = new ELearnApp1Context())
            {
                ui = await (from i in db.UserAccounts where i.Role == "Staff" select i).ToListAsync();
                return Ok(ui);
            }
        }
        [HttpGet("GetNewRequest")]
        public async Task<IActionResult> GetNewReq()
        {
            List<NewStaff> ns = new List<NewStaff>();
            UserAccount us = new UserAccount();
            ns = await us.GetNewReq();
            return Ok(ns);
        }
        [HttpPut("EditRequest")]
        public async Task<IActionResult> EditReq(int id, NewStaff n)
        {
            NewStaff ne = new NewStaff();
            using (var db = new ELearnApp1Context())
            {
                ne = await db.NewStaffs.FindAsync(id);
                ne.Status = "true";
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
