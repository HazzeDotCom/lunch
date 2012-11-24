using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lunchsajten.Service;
using Models;

namespace Lunchsajten.Controllers
{
    public class MenuController : Controller
    {
        private RestaurantsService service = new RestaurantsService();

        public ActionResult Index(long? areaId, long? restaurantId, int year = 0, int week = 0)
        {
            var now = DateTime.Now;
            week = week == 0 ? service.GetCurrentWeek() : week;
            year = year == 0 ? now.Year : year;

            var areas = service.GetLunchAreas().Where(x => x.RestaurantsCount > 0);
            areaId = areaId.HasValue ? areaId : areas.First().Id;
            var rest = restaurantId.HasValue 
                ? service.GetRestaurantWithMenu(restaurantId.Value, new SearchModel {Year = year, Week = week}) 
                : service.GetRestaurantsByLunchArea(areaId.Value).FirstOrDefault();

            var years = new[] {now.Year - 1, now.Year, now.Year + 1};
            var weeks = service.GetWeeks(year);
            var model = new MenuMakerModel
                            {
                                RestuarantName = rest.Name,
                                RestuarantId = rest.Id,
                                Areas = areas.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), Selected = x.Id == areaId }),  
                                AreaId = areaId.Value,
                                Week = week,
                                Weeks = weeks.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString(), Selected = x == week }),
                                Year = year,
                                Years = years.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString(), Selected = x == year }),
                                Restaurants = service.GetRestaurantsByLunchArea(areaId.Value).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString(), Selected = x.Id == restaurantId }),
                                Dishes = service.GetRestaurantDishes(rest.Id),
                                MenuDishes = service.GetRestaurantMenu(rest.Id, year, week)
                            };
            return View(model);
        }



    }


    
}
