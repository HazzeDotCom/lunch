using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Lunchsajten.Models;
using Lunchsajten.Service;
using Models;

namespace Lunchsajten.Controllers
{
    public class HomeController : BaseController
    {
        private RestaurantsService service = new RestaurantsService();

        public HomeController ()
        {
            
        }

        public ActionResult Index()
        {
            var now = DateTime.Now;
            ViewBag.Day = now.DayOfWeek;
            ViewBag.TodaysName = service.GetTodaysName();
            ViewBag.TodayAsString = service.GetTodayAsString();
            ViewBag.TodaysDate = service.GetTodaysDate();
            ViewBag.CurrentMonthsName = service.GetCurrentMonthsName();
            ViewBag.Year = DateTime.Now.Year;
            ViewBag.WeekNr = service.GetCurrentWeek();
            ViewBag.Names = service.GetTodaysNamesday();

            var areas = service.GetActiveLunchAreas();
            ViewBag.LunchAreas = areas;

            var a = areas.First();
            ViewBag.Title = a.Url;
            ViewBag.MetaDescription =
                string.Format("På {0} hittar du din lunchrestaurang för dagen, surfa hit och välj ditt nästa lunchställe!", a.Name);
            ViewBag.MetaKeywords = "dagens, dagens lunch, mjölby, mjolbylunch, motalalunch.se, restauranger";

            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetRestaurantsAndDishes(SearchModel model)
        {
            //sätter denna här så länge
            model.Week = CalendarManager.GetCurrentWeek();
            model.Year = DateTime.Now.Year;
            model.Day = (int)DateTime.Now.DayOfWeek;

            if (string.IsNullOrEmpty(model.SearchString)) model.SearchString = "";
            model = service.GetResturantsAndDishes(model);
            model.Partial = RenderPartialViewToString("RestaurantsPartial", model.Restaurants);

            var addsList = new List<AddsColumnRowModel>();
            var adds = service.GetAddsByLunchArea(model.AreaId).ToList();
            for (int i = 0; i < adds.Count; i++)
            {
                var item = new AddsColumnRowModel { First = adds[i], Second = adds[i+1] };
                addsList.Add(item);
                i++;
            }

            model.PartialAdds = RenderPartialViewToString("AddsColumnPartial", addsList);
            return Json(model);
        }

        public ActionResult RestaurantPartial()
        {
            return View();
        }

        public ActionResult RestaurantsPartial()
        {
            return View();
        }
    }
}
