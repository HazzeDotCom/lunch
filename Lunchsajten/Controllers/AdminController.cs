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
    public class AdminController : BaseController
    {
        private RestaurantsService restaurantsService = new RestaurantsService();
        private AdminService service = new AdminService();

        public AdminController ()
        {
            //RestaurantManager.CreateRestaurants();
        }

        public ActionResult Index()
        {
            ViewBag.ActiveTab = 1;
            var model = new AdminModel();
            var lunchareas = service.GetLunchAreas();
            model.LunchAreaId = lunchareas.First().Id;
            //model.SelectlistItemsLunchAreas =
            //    lunchareas.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString(), Selected = c.Id == model.LunchAreaId });
      
            return View(model);
        }
        

        public ActionResult DishesPartial()
        {
            return View();
        }

        public ActionResult RestaurantsPartial()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetData(AdminModel model)
        {
            switch (model.Tab.ToLower())
            {
                case "tabrestaurants":
                    var lunchareas = service.GetLunchAreas();
                    model.LunchAreaId = lunchareas.First().Id;
                    model.SelectlistItemsLunchAreas = lunchareas.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString(), Selected = c.Id == model.LunchAreaId });

                    model.Restaurants = service.GetRestaurantsByLunchAreaId(model.LunchAreaId);
                    return Json(new { Partial = RenderPartialViewToString("RestaurantsPartial", model.Restaurants) });
                case "tablunchareas":
                    model.LunchAreas = service.GetLunchAreas();
                    return Json(new { Partial = RenderPartialViewToString("LunchAreasPartial", model.LunchAreas) });
                case "tabcompanies":
                    lunchareas = service.GetLunchAreas();
                    model.LunchAreaId = lunchareas.First().Id;
                    model.SelectlistItemsLunchAreas = lunchareas.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString(), Selected = c.Id == model.LunchAreaId });
                    model.Companies = service.GetCompaniesByLunchArea(model.LunchAreaId);
                    return Json(new { Partial = RenderPartialViewToString("CompaniesPartial", model) });
                case "tblcompanies":
                    model.Companies = model.LunchAreaId > 0 ? service.GetCompaniesByLunchArea(model.LunchAreaId) : service.GetCompanies();
                   // model.CompanyCreateModel = new CompanyCreateModel();
                    return Json(new { Partial = RenderPartialViewToString("TblCompaniesPartial", model) });
                default:
                    model.LunchAreas = service.GetLunchAreas();
                    return Json(new { Partial = RenderPartialViewToString("LunchAreasPartial", model.LunchAreas) });
            }
        }
        

        [HttpPost]
        public JsonResult GetDishes(long cityid)
        {
            var dishes = service.GetDishesByLunchAreaId(cityid);
            var p = RenderPartialViewToString("DishesPartial", dishes);
            return Json(new { Partial = p });
        }

        //[HttpPost]
        //public JsonResult GetCities()
        //{
        //    var model = service.GetLunchAreas();
        //    return Json(model);
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CreateCompany(CompanyCreateModel createModel)
        {
            if (service.ExistsCompanyWithEniroId(createModel.EniroId))
            {
                createModel.CreateMsg = "Företaget med Eniroid '" + createModel.EniroId + "' finns redan i systemet!";
                return Json(createModel, JsonRequestBehavior.AllowGet);
            }
            createModel.Id = service.CreateCompany(createModel);
            return Json(createModel, JsonRequestBehavior.AllowGet);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CreateLunchArea(LunchAreaCreateModel model)
        {
            model.Id = service.CreateLunchArea(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
