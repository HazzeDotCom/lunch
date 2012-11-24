using System.Collections.Generic;
using System.Web.Mvc;

namespace Models
{
    public class SearchModel
    {
        public long AreaId { get; set; }
        public string AreaDescription { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }
        public int SearchCount { get; set; }
        public string SearchString { get; set; }
        public List<RestaurantModel> Restaurants { get; set; }
        public string Partial { get; set; }
        public string ErrorMsg { get; set; }

        //public List<AddsColumnRowModel> Adds { get; set; }
        public string PartialAdds { get; set; }

    }

    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Information { get; set; }
    }

    public class DishViewModel
    {
        public long Id { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DishType { get; set; }
        public string KitchenType { get; set; }
        public long ResturantId { get; set; }
        public string ResturantName { get; set; }
    }


    public class MenuDishViewModel
    {
        public int Day { get; set; }
        public long MenuId { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }
        public IEnumerable<MenuDayViewModel> Days { get; set; }
        public long RestaurantId { get; set; }
        public string Info { get; set; }
    }

    public class MenuDayViewModel
    {
        
    }


    public class MenuMakerModel
    {
        public int Week { get; set; }
        public string MenuInfo { get; set; }
        public long RestuarantId { get; set; }
        public string RestuarantName { get; set; }
        public List<DishViewModel> Dishes { get; set; }
        public List<MenuDishViewModel> MenuDishes { get; set; }
        public long AreaId { get; set; }
       // public SelectList Areas { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }
        public int Year { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> Weeks { get; set; }

    }


    public class AdressViewModel
    {
        public string PostArea { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Box { get; set; }
    }

    public class PhoneNumberModel
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }

}