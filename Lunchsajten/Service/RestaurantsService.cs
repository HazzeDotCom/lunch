﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Models;

namespace Lunchsajten.Service
{
    public class RestaurantsService
    {
        /// <summary>
        /// hämta alla restauranger och rätter
        /// </summary>
        public SearchModel GetResturantsAndDishes(SearchModel model)
        {
            model.AreaDescription = GetLunchAreaById(model.AreaId).Description;
            //model.Restaurants = CreateRestaurantsViewModels(RestaurantManager.GetRestaurants(model)).ToList();
            //model.Restaurants = RestaurantManager.GetRestaurants(model).Select(r => CreateRestaurantMenusViewModel(r, model)).ToList();
            model.Restaurants = RestaurantManager.GetRestaurantsWithMenus(model).Select(r => CreateRestaurantMenusViewModel(r, model)).ToList();
            model.SearchCount = model.Restaurants.Count;
            return model;
        }

        public string GetTodayAsString()
        {
            return CalendarManager.GetTodayAsTextinfo();
        }
        
        public string GetTodaysName()
        {
            return CalendarManager.GetTodaysName();
        }
        
        public int GetTodaysDate()
        {
            return CalendarManager.GetTodaysDate();
        }

        public string GetCurrentMonthsName()
        {
            return CalendarManager.GetMonth(DateTime.Now);
        }

        public int GetCurrentWeek()
        {
            return CalendarManager.GetCurrentWeek();
        }
        
        public IEnumerable<RestaurantViewModel> GetRestaurants()
        {
            return CreateRestaurantsViewModels(RestaurantManager.GetRestaurants());
        }
        
        private static IEnumerable<RestaurantViewModel> CreateRestaurantsViewModels(IEnumerable<Restaurant> restaurants)
        {
            return restaurants.Select(CreateRestaurantViewModel);
        }

        private static RestaurantModel CreateRestaurantMenusViewModel(Restaurant r, SearchModel model)
        {
            var days = r.Menus.FirstOrDefault(m => m.Week == model.Week && m.Year == model.Year).Days;
            //var day = days.FirstOrDefault(x => (int) x.DayOfWeek == model.Day);
            //var dddd = 
            var dishes = days.SelectMany( x => x.Dishes.Select(d => new MenuDishViewModel
                                        {
                                            Day = d.MenuDay.DayOfWeekId,
                                            Id = d.Dish.Id,
                                            ShortName = d.Dish.ShortName,
                                            Description = d.Dish.Description,
                                            DishType = d.Dish.DishType.ToString(),
                                            KitchenType = d.Dish.KitchenType.ToString()
                                        }));

            var rest = new RestaurantMenuViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Information = r.Information,
                Email = r.Email,
                //LunchAreas = r
                Adress =
                    new AdressViewModel
                    {
                        PostArea = r.Adress.PostArea,
                        Street = r.Adress.Street,
                        PostCode = r.Adress.PostCode
                    },
                Url = r.Url,
                Phone = r.PhoneNumbers.Any() ? r.PhoneNumbers.FirstOrDefault().Number : "", //   r.PhoneNumbers.FirstOrDefault().Number,
                //  Contact = new UserViewModel(), // new UserViewModel { Email = r.Contacts.FirstOrDefault().Email, Id = r.Contacts.FirstOrDefault().Id, FirstName = r.Contacts.FirstOrDefault().FirstName, LastName = r.Contacts.FirstOrDefault().LastName, Phone = r.Contacts.FirstOrDefault().PhoneNumbers.FirstOrDefault().Number },
                Dishes = dishes 
            };
            return rest;
        }

        private static RestaurantViewModel CreateRestaurantViewModel(Restaurant r)
        {
            var rest =  new RestaurantViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description,
                        Information = r.Information,
                        Email = r.Email, 
                        //LunchAreas = r
                        Adress =
                            new AdressViewModel
                            {
                                PostArea = r.Adress.PostArea,
                                Street = r.Adress.Street,
                                PostCode = r.Adress.PostCode
                            },
                        Url = r.Url,
                        Phone = r.PhoneNumbers.Any() ? r.PhoneNumbers.FirstOrDefault().Number : "", //   r.PhoneNumbers.FirstOrDefault().Number,
                      //  Contact = new UserViewModel(), // new UserViewModel { Email = r.Contacts.FirstOrDefault().Email, Id = r.Contacts.FirstOrDefault().Id, FirstName = r.Contacts.FirstOrDefault().FirstName, LastName = r.Contacts.FirstOrDefault().LastName, Phone = r.Contacts.FirstOrDefault().PhoneNumbers.FirstOrDefault().Number },
                        Dishes = r.Dishes.Select(d => new DishViewModel { Id = d.Id, ShortName = d.ShortName, Description = d.Description, DishType = d.DishType.ToString(), KitchenType =  d.KitchenType.ToString() }).ToList()
                    };
            return rest;
        }

        public IEnumerable<RestaurantViewModel> GetRestaurantsByLunchArea(long lunchAreaId)
        {
            return CreateRestaurantsViewModels(RestaurantManager.GetRestaurantsByLunchArea(lunchAreaId));
        }

        public IEnumerable<DishViewModel> GetDishes()
        {
            return CreateDishViewModels(RestaurantManager.GetDishes());
        }

        private static IEnumerable<DishViewModel> CreateDishViewModels(IEnumerable<Dish> dishes)
        {
            return dishes.Select(CreateDishViewModel);
        }

        private static DishViewModel CreateDishViewModel(Dish d)
        {
            return new DishViewModel
            {
                Id = d.Id, ShortName = d.ShortName,
                Description = d.Description, DishType = d.DishType.ToString(), 
                ResturantName = d.Restaurant.Name, ResturantId = d.Restaurant.Id, 
                KitchenType = d.KitchenType.ToString()
            };
        }

        public LunchAreaViewModel GetLunchAreaById(long id)
        {
            return MapLunchAreaToModel(AdminManager.GetLunchAreaById(id));
        }

        private static LunchAreaViewModel MapLunchAreaToModel(LunchArea l)
        {
            var model = new LunchAreaViewModel()
                            {Id = l.Id, Name = l.Name, Status = l.LunchAreaStatus.ToString(), Url = l.Url, Description = l.Description, RestaurantsCount = l.Restaurants.Count};
            return model;
        }

        public IEnumerable<LunchAreaViewModel> GetLunchAreas()
        {
            return AdminManager.GetLunchAreas().Select(MapLunchAreaToModel);
        }
        
        public IEnumerable<LunchAreaViewModel> GetActiveLunchAreas()
        {
            return AdminManager.GetLunchAreas().Where(l => l.LunchAreaStatus == LunchAreaStatus.Active).Select(MapLunchAreaToModel);
        }

        public string GetTodaysNamesday()
        {
            var now = DateTime.Now;
            var key = string.Format("{0}/{1}", now.Day, now.Month) ;
            return AdminManager.GetTodaysNamesDay(key);
        }

        /// <summary>
        /// return a randomized list
        /// </summary>
        public IEnumerable<AdvertiseViewModel> GetAddsByLunchArea(long areaId)
        {
            var adds = AdminManager.GetAddsByLunchAreaId(areaId);
            var randomizedList = adds.OfType<Advertise>().OrderBy(o => Guid.NewGuid());
            return randomizedList.Select(CreateAdvertiseViewModel);
        }

        private static AdvertiseViewModel CreateAdvertiseViewModel(Advertise a)
        {
            return new AdvertiseViewModel
            {
                Id = a.Id,
                CompanyInfo = a.Company.Information,
                CompanyName = a.Company.Name,
                CompanyUrl = a.Company.Url,
                ImageUrl = a.Image.ImageUrl
            };
        }

        public RestaurantModel GetRestaurantWithMenu(long restaurangId, SearchModel model)
        {
            var r = CreateRestaurantMenusViewModel(RestaurantManager.GetRestaurant(restaurangId), model);
            return r;
        }

        public List<int> GetWeeks(int year)
        {
            return CalendarManager.GetWeeks(year);
        }

        public List<DishViewModel> GetRestaurantDishes(long restaurantId)
        {
            var r = RestaurantManager.GetRestaurant(restaurantId);
            return r.Dishes.Select(CreateDishViewModel).ToList();
        }
        
        public MenuDishViewModel GetRestaurantMenu(long restaurantId, int year, int week)
        {
            var menu = RestaurantManager.GetRestaurant(restaurantId).Menus.FirstOrDefault(m => m.Week == week && m.Year == year);
            return CreateMenuViewModel(menu); 
        }

        private MenuDishViewModel CreateMenuViewModel(Menu menu)
        {
            var m = new MenuDishViewModel
                        {
                            Info = menu.Info,
                            MenuId = menu.Id,
                            RestaurantId = menu.Restaurant.Id,
                            Week = menu.Week,
                            Year = menu.Year,
                            Days = CreateMenuDaysViewModel(menu.Days)
                        };
            return m;
        }

        private IEnumerable<MenuDayViewModel> CreateMenuDaysViewModel(ICollection<MenuDay> days)
        {
            return days.Select(d => new )
            throw new NotImplementedException();
        }
    }
}