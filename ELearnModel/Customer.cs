using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class Customer
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string Debit { get; set; }
        public int Cvv { get; set; }
        public string Expiry { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
