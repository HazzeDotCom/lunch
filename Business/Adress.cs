using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Adress : Entity
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Box { get; set; }
        public string PostArea { get; set; }
        //public virtual City City { get; set; }
    }
}
