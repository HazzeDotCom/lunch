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
            var result = GetRestaurants().Where(m => m.Menus.Any()).Where(l => l.Areas.Any(x => x.Id == model.AreaId)).ToList(); 
            
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

        //public static IEnumerable<Restaurant> GetRestaurantsByCity(long cityId)
        //{
        //    var db = new DataContext();
        //    var name = db.LunchAreas.FirstOrDefault(c => c.Id == cityId).Name;
        //    return db.Restaurants.Where(r => r.Area.Name == name);
        //}

        public static IEnumerable<Dish> GetDishes()
        {
            var db = new DataContext();
            return db.Dishes;
        }

        public static IEnumerable<Restaurant> GetRestaurantsByLunchArea(long lunchAreaId)
        {
            throw new NotImplementedException();
        }
    }
}