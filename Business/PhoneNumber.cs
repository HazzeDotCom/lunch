using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class PhoneNumber : Entity
    {
        [Required]
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
    }
}
