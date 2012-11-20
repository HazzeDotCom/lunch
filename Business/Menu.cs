using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Menu : Entity
    {
        public Menu()
        {
            Days = new List<MenuDay>();
        }
        public int Week { get; set; }
        public int Year { get; set; }
        public virtual ICollection<MenuDay> Days { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public string Info { get; set; }
    }
}
