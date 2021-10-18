using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class UserAccount:IUserAccount<UserAccount>
    {
        private readonly ELearnApp1Context db = new ELearnApp1Context();

       // UserAccount us = new UserAccount();
        public UserAccount()
        {
            Answers = new HashSet<Answer>();
            CourseEnrolls = new HashSet<CourseEnroll>();
            Courses = new HashSet<Course>();
            Customers = new HashSet<Customer>();
            Fees = new HashSet<Fee>();
            Questions = new HashSet<Question>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }

        
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string UserImage { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        //public UserAccount(ELearnApp1Context _db)
        //{
        //    db = _db;
        //}

        public List<UserAccount> GetUserAccountsCredential()
        {
            return db.UserAccounts.ToList();
        }
        public void AddUser(UserAccount u)
        {
            db.UserAccounts.Add(u);
            db.SaveChanges();
        }

        //public  Task<string> Login(Login u)
        //{
        //    UserAccount us =  (from i in db.UserAccounts where i.Username == u.Username && i.Password == u.Password select i).FirstOrDefault();
        //}

        //public async Task<List<UserAccount>> GetDetail(Login u)
        //{
        //  return  db.UserAccounts.ToList();
        //}

        public async Task<UserAccount> GetDetailByUsername(string name)
        {
            UserAccount u = (from i in db.UserAccounts where i.Username == name select i).FirstOrDefault();
            return u;
        }

        //public Task<bool> CheckAuthentication()
        //{
        //    if (Request.Cookies["valid"] != null)
        //    {
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return Ok(false);
        //    }
        //}

        public async Task<List<UserAccount>> GetStudentList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db = new ELearnApp1Context())
            {
                ui = (from i in db.UserAccounts where i.Role == "Student" select i).ToList();
                return ui;
            }
        }

        public async Task<List<UserAccount>> GetStaffList()
        {
            List<UserAccount> ui = new List<UserAccount>();
            using (var db = new ELearnApp1Context())
            {
                ui = (from i in db.UserAccounts where i.Role == "Staff" select i).ToList();
                return ui;
            }
        }

        //public async Task<List<NewStaff>> GetNewReq()
        //{

        //    List<NewStaff> ls = new List<NewStaff>();
        //    using (var db = new ELearnApp1Context())
        //    {
        //        ls = (from i in db.NewStaffs where i.Status == "false" select i).ToList();
        //        return ls;
        //    }
        //}

       

        public async Task<List<NewStaff>> GetNewReq()
        {

            List<NewStaff> ls = new List<NewStaff>();
            using (var db = new ELearnApp1Context())
            {
                ls = (from i in db.NewStaffs where i.Status == "false" select i).ToList();
                return ls;
            }
        }

       // public async Task<List<UserAccount>> GetDetail(Login u)
       // {
       //     return db.UserAccounts.ToList();
       // }

       public async Task<List<UserAccount>>GetDetail(Login u)
       {
            return db.UserAccounts.ToList();
        }

        Task<UserAccount> IUserAccount<UserAccount>.GetDetail(Login u)
        {
            throw new NotImplementedException();
        }







        //public async  Task<List<UserAccount>> EditReq(int id, NewStaff n)
        //{

        //    List<NewStaff> ne = new List<NewStaff>();
        //    using (var db = new ELearnApp1Context())
        //    {
        //        db.Entry(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        //ne = db.NewStaffs.Find(id);
        //        ne.Status = "true";
        //         db.SaveChangesAsync();
        //        return ne;


        //}
    }
}
