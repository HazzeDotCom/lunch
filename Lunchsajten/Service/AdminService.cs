using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business;
using Models;

namespace Lunchsajten.Service
{
    public class AdminService
    {
        public string GetTodayAsString()
        {
            return CalendarManager.GetTodayAsTextinfo();
        }

        public int GetCurrentWeek()
        {
            return CalendarManager.GetCurrentWeek();
        }

        public IEnumerable<LunchAreaViewModel> GetLunchAreas()
        {
            return AdminManager.GetLunchAreas().Select(MapLunchAreaToViewModel);
        }

        private static LunchAreaViewModel MapLunchAreaToViewModel(LunchArea l)
        {
            return new LunchAreaViewModel
            {
                Status = l.LunchAreaStatus.ToString(),
                Id = l.Id,
                Name = l.Name, Description = l.Description,
                Url = l.Url,
                RestaurantsCount = l.Restaurants.Count,
                //AdvertisesCount = AdminManager.get.GetAdvertisesByLunchAreaId(l.Id).Count()
            };
        }

        //public IEnumerable<RestaurantViewModel> GetRestaurants()
        //{
        //    return RestaurantManager.GetRestaurants();
        //}

        //public IEnumerable<DishViewModel> GetDishes()
        //{
        //    return RestaurantManager.GetDishes();
        //}

        public long CreateCompany(CompanyCreateModel createModel)
        {
            return CompanyManager.CreateCompany(createModel);
        }

        public IEnumerable<CompanyViewModel> GetCompanies()
        {
            return new CompanyService().GetCompaniesAll(); // CompanyManager.GetCompaniesAll(); //.Companies().Select(MapCompanyToViewModel);
        }

        //public IEnumerable<CompanyViewModel> GetCompaniesByLunchArea(long id)
        //{
        //    var cs = new CompanyService();
        //    return new CompanyService()..CompaniesByLunchArea(id).Select(MapCompanyToViewModel);
        //}
        
        public IEnumerable<CompanyViewModel> GetCompaniesByLunchArea(long id)
        {
            return new CompanyService().GetCompaniesByLunchArea(id); //.Select(MapCompanyToViewModel);
        }

        //private static CompanyViewModel MapCompanyToViewModel(Company c)
        //{
        //    return new CompanyViewModel
        //                {
        //                    CompanyName = c.Name,
        //                    //Box = c.Adress.Box, 
        //                    //LunchareaName = c.City.Name,
        //                   // PostCode = c.Adress.PostCode, Email = c.Email, Url = c.Url,
        //                    //Street = c.Adress.Street, EniroId = c.EniroId, 
        //                    Id = c.Id, 
        //                    Information = c.Information, 
        //                    //Notes = c.Notes, 
        //                    Organisationnr = c.Organisationnr, 
        //                    Latitude = c.Latitude, 
        //                    Longitude = c.Longitude, 
        //                    AddsCount = c.Advertises.Count, 
        //                    RestuarantsCount = c.Restaurants.Count
        //                };
        //}

        public SelectList GetDishTypes(int selected)
        {
            return new SelectList(AdminManager.GetDishTypes(), "ID", "Name", selected);
        }
        
        public SelectList GetKitchenTypes(int selected)
        {
            return new SelectList(AdminManager.GetKitchenTypes(), "ID", "Name", selected);
        }

        public IEnumerable<DishViewModel> GetDishesByLunchAreaId(long id)
        {
            return AdminManager.GetDishesByLunchAreaId(id).Select(MapDishToViewModel);
        }

        private static DishViewModel MapDishToViewModel(Dish d)
        {
            return new DishViewModel
                       {
                           Id = d.Id,
                           Description = d.Description,
                           ResturantId = d.Restaurant.Id,
                           ResturantName = d.Restaurant.Name,
                           ShortName = d.ShortName,
                           DishType = d.DishType.ToString(),
                           KitchenType = d.KitchenType.ToString()
                       };
        }

        public IEnumerable<RestaurantViewModel> GetRestaurantsByLunchAreaId(long id)
        {
            return RestaurantManager.GetRestaurantsByLunchAreaId(id).Select(MapRestaurantToViewModel);
        }
        

        private static RestaurantViewModel MapRestaurantToViewModel(Restaurant r)
        {
            return new RestaurantViewModel
                       {
                           CompanyId = r.Company.Id,
                           CompanyName = r.Company.Name,
                           Description = r.Description,
                           Email = r.Email,
                           Id = r.Id,
                           Information = r.Information,
                           Url = r.Url,
                           Name = r.Name,
                           Phone = r.PhoneNumbers.FirstOrDefault().Number,
                           DishesCount = r.Dishes.Count
                       };
        }

        public bool ExistsCompanyWithEniroId(int eniroId)
        {
            return CompanyManager.EniroIdExists(eniroId); 
        }

        public long CreateLunchArea(LunchAreaCreateModel model)
        {
            return AdminManager.CreateLunchArea(model);
        }
    }
}