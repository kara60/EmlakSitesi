using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Semt> Semts { get; set; }
    }
}