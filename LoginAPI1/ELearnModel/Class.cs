﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LoginAPI1.ELearnModel
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public int? CourseId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string CLink { get; set; }
        public DateTime ClassDate { get; set; }

        public virtual Course Course { get; set; }
    }
}
