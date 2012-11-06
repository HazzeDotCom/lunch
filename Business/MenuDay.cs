using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class MenuDay : Entity
    {
        public virtual ICollection<Dish> Dishes { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string Message { get; set; }
    }
}
