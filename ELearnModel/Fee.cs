﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class Fee
    {
        public int FeeId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
