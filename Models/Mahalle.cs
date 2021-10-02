using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class Mahalle
    {
        public int MahalleId { get; set; }
        public string MahalleName { get; set; }
        public int SemtId { get; set; }
        public virtual Semt Semt { get; set; }
    }
}