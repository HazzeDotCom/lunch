using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Information { get; set; }
        //public long AdressId { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
