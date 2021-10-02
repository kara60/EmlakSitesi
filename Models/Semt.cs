using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class Semt
    {
        public int SemtId { get; set; }
        public string SemtName { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public List<Mahalle> Mahalles { get; set; }
    }
}