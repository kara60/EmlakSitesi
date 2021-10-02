using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakProject.Models
{
    public class Ilan
    {
        public int IlanId { get; set; }
        public string IlanDescription { get; set; }
        public double Price { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public bool Credit { get; set; }
        public int Alan { get; set; }
        public string Floor { get; set; }
        public string TelNo { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public int CityId { get; set; }
        public int SemtId { get; set; }
        public int DurumId { get; set; }

        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }

        public int TipId { get; set; }
        public Tip Tip { get; set; }

        public List<Image> Images { get; set; }
    }
}