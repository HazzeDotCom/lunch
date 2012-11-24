using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
    public static class RestaurantManager
    {
        public static IEnumerable<Restaurant> GetRestaurants()
        {
            var db = new DataContext();
            return db.Restaurants;
        }

        public static long CreateRestaurant(Restaurant r, List<long> areaIds)
        {
            using (var db = new DataContext())
            {
                r.Company = db.Companies.Find(r.Company.Id);
               
                db.Restaurants.Add(r);
                foreach (var id in areaIds)
                {
                    r.Areas.Add(db.LunchAreas.Find(id));
                }
                db.SaveChanges();
            }
            return r.Id;
        }

        public static List<Restaurant> GetRestaurants(SearchModel model)
        {
            var result = GetRestaurants().Where(l => l.Areas.Any(x => x.Id == model.AreaId)).ToList(); 
            
            if (string.IsNullOrEmpty(model.SearchString))
                return result.ToList();

            var str = model.SearchString.ToLower();
            var filteredList = result.Where(r => 
                r.Name.ToLower().Contains(str) || r.Information.ToLower().Contains(str) 
                || (r.Dishes.Any(d => d.ShortName.ToLower().Contains(str)) ||
                r.Dishes.Any(d => d.Description.ToLower().Contains(str))) 
                );

            return filteredList.Any() ? filteredList.ToList() : null;
        }

        public static List<Restaurant> GetRestaurantsWithMenus(SearchModel model)
        {
            var result = GetRestaurants().Where(m => m.Menus.Any())
                .Where(l => l.Areas.Any(x => x.Id == model.AreaId)).ToList(); 
            
            if (string.IsNullOrEmpty(model.SearchString))
                return result.ToList();

            var str = model.SearchString.ToLower();
            var filteredList = result.Where(r => 
                r.Name.ToLower().Contains(str) || r.Information.ToLower().Contains(str) 
                || (r.Dishes.Any(d => d.ShortName.ToLower().Contains(str)) ||
                r.Dishes.Any(d => d.Description.ToLower().Contains(str))) 
                );

            return filteredList.Any() ? filteredList.ToList() : null;
        }
        
        
        private static long CreateRestaurant(RestaurantEditModel model)
        {
            using (var db = new DataContext())
            {
                var r = new Restaurant
                            {
                                Name = model.Name,
                                Email = model.Email,
                               // Company = db.Companies.Find(model.Company.Id),
                                Url = model.Url,
                                Description = model.Description,
                                Information = model.Information,
                               // Area = model. db.LunchAreas.Find(model.CityId),
                                Adress =
                                    new Adress
                                        {
                                            PostCode = model.Adress.PostCode,
                                            Street = model.Adress.Street,
                                            
                                        }
                            };
                db.Restaurants.Add(r);
                db.SaveChanges();
                return r.Id;
            }
        }
        
        public static Restaurant GetRestaurant(long id)
        {
            var db = new DataContext();
            return db.Restaurants.Find(id);
        }

        public static IEnumerable<Dish> GetDishes()
        {
            var db = new DataContext();
            return db.Dishes;
        }

        public static IEnumerable<Restaurant> GetRestaurantsByLunchArea(long lunchAreaId)
        {
            var db = new DataContext();
            var rests = db.Restaurants.Where(r => r.Areas.Any(l => l.Id == lunchAreaId));
            return rests;
        }

        public static IEnumerable<Restaurant> GetRestaurantsByLunchAreaId(long id)
        {
            var db = new DataContext();
            return db.Restaurants.Where(r => r.Areas.Any(a => a.Id == id));
        }

        public static Menu CreateMenu(Restaurant r, int week, int year, string info)
        {
            var m = new Menu() {Week = week, Year = year, Info = info};
            using(var db = new DataContext())
            {
                m.Restaurant = db.Restaurants.Find(r.Id);
                db.Menus.Add(m);
                db.SaveChanges();
            }
            return m;
        }

        public static void CreateMenuDay(MenuDay md)
        {
            using(var db = new DataContext())
            {
                foreach (var menuDish in md.Dishes)
                {
                    menuDish.Dish.Restaurant = db.Restaurants.Find(menuDish.Dish.Restaurant.Id);
                }

                md.DayOfWeekId = (int) md.DayOfWeek;
                md.Menu = db.Menus.Find(md.Menu.Id);
                db.MenuDays.Add(md);
                db.SaveChanges();
            }
        }

        public static void CreateDish(Dish dish)
        {
            using(var db = new DataContext())
            {
                var rest = db.Restaurants.Find(dish.Restaurant.Id);
                dish.Restaurant = rest;
                rest.Dishes.Add(dish);
                db.SaveChanges();
            }
        }
    }
}