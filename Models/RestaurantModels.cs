using System.Collections.Generic;
using System.Web.Mvc;

namespace Models
{
    public abstract class MasterModelAdmin
    {
        public IEnumerable<SelectListItem> SelectlistItemsLunchAreas { get; set; }
        public long SelectedLunchAreaId { get; set; }
        public string LunchAreaName { get; set; }
        public string Username { get; set; }
    }

    public class RestaurantsViewModel : MasterModelAdmin
    {
        public IEnumerable<RestaurantModel> Restaurants { get; set; }
    }

    public class RestaurantModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public AdressViewModel Adress { get; set; }
        public string Information { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public UserViewModel Contact { get; set; }
        public string Description { get; set; }
        public int DishesCount { get; set; }
    }

    public class RestaurantViewModel : RestaurantModel
    {
        //public RestaurantViewModel()
        //{
        //    this.Dishes = new List<DishViewModel>();
        //}
      //  public List<LunchAreaViewModel> LunchAreas { get; set; }
        public IEnumerable<DishViewModel> Dishes { get; set; }
    }

    public class RestaurantMenuViewModel : RestaurantModel
    {
        //public RestaurantViewModel()
        //{
        //    this.Dishes = new List<DishViewModel>();
        //}
        //  public List<LunchAreaViewModel> LunchAreas { get; set; }
        public IEnumerable<MenuDishViewModel> Dishes { get; set; }
    }

    public class RestaurantEditModel : RestaurantModel
    {
        

    }
}