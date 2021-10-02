using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int IlanId { get; set; }
        public virtual Ilan Ilan { get; set; }
    }
}