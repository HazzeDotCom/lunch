using System.Collections.Generic;

namespace Models
{
    public class SearchModel
    {
        public long AreaId { get; set; }
        public string AreaDescription { get; set; }
        public int Day { get; set; }
        public int SearchCount { get; set; }
        public string SearchString { get; set; }
        public List<RestaurantViewModel> Restaurants { get; set; }
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