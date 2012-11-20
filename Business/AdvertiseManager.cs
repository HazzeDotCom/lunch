using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
    public static class ImageManager
    {
        public static Image CreateImage(string imgUrl)
        {
            var image = new Image { ImageUrl = imgUrl };
            using (var db = new DataContext())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
            return image;
        }
    }

    public static class AdvertiseManager
    {
        public static long CreateAdvertise(Company c, List<LunchArea> areas, Image img)
        {
            var ad = new Advertise { Company = c, Image = img };
            using (var db = new DataContext())
            {
                c.Advertises.Add(ad);
                var dbAreas = areas.Select(a => db.LunchAreas.Find(a.Id)).ToList();
                var advertiseAreas = dbAreas.Select(a => new AdvertiseArea { LunchArea = a, Advertise = ad });
                //var advertiseAreas = areas.Select(a => new AdvertiseArea { LunchArea = a, Advertise = ad });
                foreach (var a in advertiseAreas)
                {
                    ad.Areas.Add(a);
                }
                db.SaveChanges();
            }
            return ad.Id;
        }
    }
}