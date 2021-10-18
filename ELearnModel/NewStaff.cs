using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class NewStaff:INewStaff<NewStaff>
    {
        public int Sid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string High { get; set; }
        public string Department { get; set; }
        public string College { get; set; }
        public string Experience { get; set; }
        public string Status { get; set; }
        public string UserImage { get; set; }
        public string Email { get; set; }

        public void AddRequest(NewStaff n)
        {
            using (var db = new ELearnApp1Context())
            {
                var s=db.NewStaffs.Add(n);
                db.SaveChangesAsync();
                
            }
        }
       
    }
}
