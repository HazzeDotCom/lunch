using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class Advertise : Entity
    {
        public Advertise()
        {
            Areas = new List<AdvertiseArea>();
        }

        //public Advertise(Image img, LunchArea area)
        //{
        //    Image = img;;
        //    Areas = new List<AdvertiseArea> { new AdvertiseArea{ LunchArea = area, Advertise = this } };
        //}

        //public Advertise(Image img, IEnumerable<LunchArea> areas, Company comp)
        //{
        //    Company = comp;
        //    Image = img;
        //    Areas = areas.Select(a => new AdvertiseArea{ LunchArea = a, Advertise = this }).ToList();
        //}

        public AdvertiseType Type { get; set; }
        public virtual Image Image { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<AdvertiseArea> Areas { get; set; }
    }

    public class AdvertiseArea : Entity
    {
        public virtual Advertise Advertise { get; set; }
        public virtual LunchArea LunchArea { get; set; }
    }
}
