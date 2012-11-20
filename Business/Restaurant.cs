using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class Restaurant : Entity
    {
        public Restaurant()
        {
            Areas = new List<LunchArea>();
            Menus = new List<Menu>();
        }

        public Restaurant(string name, string number, string info, string url)
        {
            Name = name.Trim();
            if (!string.IsNullOrWhiteSpace(number))
            {
                PhoneNumbers = new List<PhoneNumber>();
                this.AddNumber(number.Trim());
            }
            Information = info.Trim();
            Url = url.Trim();
            Dishes = new List<Dish>();
            Areas = new List<LunchArea>();
            Adress = new Adress();
            Menus = new List<Menu>();
        }

        [Required]
        public string Name { get; set; }
        public string Information { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public KitchenType KitchenType { get; set; }
        public virtual ICollection<LunchArea> Areas { get; set; }

        //[Required]
        //public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        
        public virtual Adress Adress { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<User> Contacts { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        public void AddNumber(string number)
        {
            PhoneNumbers.Add(new PhoneNumber(){Number = number, Type = PhoneNumberType.Standard});
        }

        

        public void SetDataFromCompany(Company c, LunchArea area)
        {
            this.Name = c.Name;
            this.Adress = c.Adress;
            this.Company = c;
            this.Email = c.Email;
            this.Information = c.Information;
            this.Url = c.Url;
            if (!Areas.Any(a => a.Id == area.Id))
            {
                this.Areas.Add(area);
            }
        }

        public Menu GetCurrentWeeksMenu()
        {
            var week = CalendarManager.GetCurrentWeek();
            return null;

        }

        public IEnumerable<MenuDay> GetDays(int week, int year)
        {
            var menu = Menus.First(m => m.Week == week && m.Year == year);
            var days = menu.Days;
            return days;
        }
    }
}
