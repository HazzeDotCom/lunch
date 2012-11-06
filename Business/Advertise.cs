using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Advertise : Entity
    {
        public AdvertiseType Type { get; set; }
        //todo - denna kanske ska vara egen class?
        public string ImageUrl { get; set; }
        public virtual Company Company { get; set; }
        public virtual LunchArea LunchArea { get; set; }
    }
}
