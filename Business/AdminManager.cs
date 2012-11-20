using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Models;

namespace Business
{
    public static class AdminManager
    {
        
        public static IEnumerable<LunchArea> GetLunchAreas()
        {
            var db = new DataContext();
            return db.LunchAreas.ToList().OrderBy(o => o.Name);
        }
        
        public static LunchArea GetLunchAreaById(long id)
        {
            var db = new DataContext();
            return db.LunchAreas.Find(id);
        }

        public static Dictionary<int, string> GetDishTypes()
        {
            return Enum.GetValues(typeof(DishType)).Cast<object>().ToDictionary(type => (int) type, type => type.ToString());
        }
        
        public static Dictionary<int, string> GetKitchenTypes()
        {
            return Enum.GetValues(typeof(KitchenType)).Cast<object>().ToDictionary(type => (int)type, type => type.ToString());
        }

        //public static IEnumerable<Advertise> GetAdvertisesByLunchAreaId(long id)
        //{
        //    var db = new DataContext();
        //    return db.Advertises.Where(a => a.Company.City.Id == id);
        //}

        //public static IEnumerable<Restaurant> GetRestaurantsByCityId(long id)
        //{
        //    var db = new DataContext();
        //    return db.Restaurants.Where(r => r.City.Id == id);
        //}

        //public static IEnumerable<Dish> GetDishesByCityId(long id)
        //{
        //    var db = new DataContext();
        //    return db.Dishes.Where(d => d.Restaurant.City.Id == id);
        //}
        

        public static IEnumerable<Dish> GetDishesByLunchAreaId(long id)
        {
            var db = new DataContext();
            return (IEnumerable<Dish>) db.Restaurants.Where(l => l.Areas.Any(a => a.Id == id)).Select(d => d.Dishes);
            //return db.Dishes.Where(d => d.Restaurant.Areas.Any(l => l.Id.Equals(id)));
        }

        

        public static string GetTodaysNamesDay(string key)
        {
            var db = new DataContext();
            return db.NameDays.FirstOrDefault(n => n.Key == key).Names;
        }

        public static long CreateLunchArea(LunchAreaCreateModel model)
        {
            var l = new LunchArea()
            {
                Description = model.Description,
                Name = model.Name,
                Url = model.Url,
                LunchAreaStatus = LunchAreaStatus.New
            };

            using (var db = new DataContext())
            {
                db.LunchAreas.Add(l);
                db.SaveChanges();
            }
            return l.Id;
        }

        public static IEnumerable<Advertise> GetAddsByLunchAreaId(long areaId)
        {
            var db = new DataContext();
            var areas = db.AdvertiseAreas.Where(x => x.LunchArea.Id == areaId).ToList(); 
            return areas.Where(a => a.LunchArea.Id == areaId).Select(x => x.Advertise);
        }

        public static long CreateLunchArea(LunchArea l)
        {
            using (var db = new DataContext())
            {
                if(!db.LunchAreas.Any(la => la.Name.ToLower().Equals(l.Name.ToLower())))
                {
                    db.LunchAreas.Add(l);
                    db.SaveChanges();    
                }
            }
            return l.Id;
        }
    }
}