using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Menu : Entity
    {
        public int Week { get; set; }
        public int Year { get; set; }
        public ICollection<Day> Days { get; set; }
        public string Info { get; set; }
    }
}
