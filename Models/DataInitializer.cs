using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmlakProject.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var city = new List<City>()
            {
                new City() {CityName="İstanbul"},
                new City() {CityName="Ankara"},
                new City() {CityName="İzmir"},
            };
            foreach (var item in city)
            {
                context.Cities.Add(item);
            }
            context.SaveChanges();

            var semt = new List<Semt>()
            {
                new Semt(){SemtName="Beşiktaş", CityId=1},
                new Semt(){SemtName="Keçiören", CityId=2},
                new Semt(){SemtName="Karşıyaka", CityId=3},
            };
            foreach (var item in semt)
            {
                context.Semts.Add(item);
            }
            context.SaveChanges();

            var mahalle = new List<Mahalle>()
            {
                new Mahalle(){MahalleName="Su", SemtId=1},
                new Mahalle(){MahalleName="Kümbet", SemtId=2},
                new Mahalle(){MahalleName="Çay", SemtId=3},
            };
            foreach (var item in mahalle)
            {
                context.Mahalles.Add(item);
            }
            context.SaveChanges();

            var durum = new List<Durum>()
            {
                new Durum(){DurumName="Kiralık"},
                new Durum(){DurumName="Satılık"},
            };
            foreach (var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();

            var tip = new List<Tip>()
            {
                new Tip(){TipName="Arsa", DurumId=2},
                new Tip(){TipName="Ev", DurumId=1},
            };
            foreach (var item in tip)
            {
                context.Tips.Add(item);
            }
            context.SaveChanges();

            var ilan = new List<Ilan>()
            {
                new Ilan(){IlanDescription="Güzel Ev", Address="demirköprü karş.", NumberOfRooms=6, Credit=true, Price=2000, MahalleId=1, SemtId=1, CityId=1, DurumId=1, TipId=2, Alan=200,TelNo="05445677889",Floor="5. Kat", UserName="eneskara"},
            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();

            var image = new List<Image>()
            {
                new Image(){ImageName="1.jpg",IlanId=1},
                new Image(){ImageName="2.jpg",IlanId=1},
            };
            foreach (var item in image)
            {
                context.Images.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}