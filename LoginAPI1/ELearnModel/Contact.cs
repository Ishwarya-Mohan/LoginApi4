using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class Contact:IContact<Contact>
    {
        public int Cid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public void AddContact(Contact n)
        {
            using (var db = new ELearnApp1Context())
            {
                db.Contacts.Add(n);
                 db.SaveChangesAsync();
                
            }

        }
    }

}
