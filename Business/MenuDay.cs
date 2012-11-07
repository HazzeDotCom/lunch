using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class MenuDay : Entity
    {
        public virtual ICollection<MenuDish> Dishes { get; set; }
        public int DayOfWeekId { get; set; }
        public string Message { get; set; }
        public virtual Menu Menu { get; set; }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return (DayOfWeek)DayOfWeekId;
            }
            set
            {
                DayOfWeekId = (int)value;
            }
        }
    }
}
