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
        //private static Lan GetLänById(long id)
        //{
        //    return Lan.FirstOrDefault(l => l.Id == id);
        //}

        //private static Landskap GetLandskapById(long id)
        //{
        //    return Landskap.FirstOrDefault(l => l.Id == id);
        //}

        //private static Landsdel GetLandsdelById(long id)
        //{
        //    return Landsdelar.FirstOrDefault(l => l.Id == id);
        //}

        //private static Lan GetLänByName(string str)
        //{
        //    str = str.Trim();
        //    using (var db = new DataContext())
        //    {
        //        return db.Lan.FirstOrDefault(c => c.Name == str);
        //    }
        //}

        //private static Landskap GetLandskapByName(string str)
        //{
        //    str = str.Trim();
        //    using (var db = new DataContext())
        //    {
        //        return db.Landskap.FirstOrDefault(c => c.Name == str);
        //    }
        //}

        //private static Landsdel GetLandsdelByName(string str)
        //{
        //    str = str.Trim();
        //    using (var db = new DataContext())
        //    {
        //        return db.Landsdelar.FirstOrDefault(c => c.Name == str);
        //    }
        //}
        
        
        private static long CreateRestaurant(RestaurantEditModel model)
        {
            //todo - lagra i databas
            return 666;
        }
        
        private static long SaveRestaurant(RestaurantEditModel model)
        {
            //todo - lagra i databas
            return 666;
        }
        
        private static RestaurantViewModel LoadRestaurant(long id)
        {
            //todo - 
            return new RestaurantViewModel(){Id = 666};
        }

        public static long CreateCompany(CompanyCreateModel createModel)
        {
            var db = new DataContext();
            var c = new Company(createModel.IsRestaurant)
                        {
                            Name = createModel.CompanyName,
                            Organisationnr = createModel.Organisationnr, 
                            Information = createModel.Information, Notes = createModel.Notes, 
                            Latitude = createModel.Latitude, Longitude = createModel.Longitude, EniroId = createModel.EniroId,
                            Email = createModel.Email, Url = createModel.Url, 
                            //PhoneNumbers = model.PhoneNumbers.Select(p => new PhoneNumber {
                            //    Number = p.Number,
                               // Type = (PhoneNumberType) p.Type
                           // }).ToList(),
                            Adress = new Adress
                                    {
                                        PostCode = createModel.PostCode,
                                        Street = createModel.Street,
                                        PostArea = createModel.PostArea
                                    }};
            
            try
            {
                db.Companies.Add(c);
                //c.Adress.City = db.Cities.Find(c.Adress.City.Id);

                if (createModel.IsRestaurant)
                {
                    var r = new Restaurant();
                    var area = db.LunchAreas.Find(createModel.LunchAreaId);
                    r.SetDataFromCompany(c, area);
                    r.Areas.Add(area);
                    db.Restaurants.Add(r);
                }
                db.SaveChanges();
                return c.Id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }    
        }

        
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

        public static IEnumerable<Company> Companies()
        {
            var db = new DataContext();
            return db.Companies.OrderBy(o => o.Name);
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
            return db.Dishes.Where(d => d.Restaurant.Areas.Any(l => l.Id.Equals(id)));
        }

        public static IEnumerable<Restaurant> GetRestaurantsByLunchAreaId(long id)
        {
            var db = new DataContext();
            return db.Restaurants.Where(r => r.Areas.Any(a => a.Id == id));
        }

        public static IEnumerable<Company> CompaniesByLunchArea(long id)
        {
            var db = new DataContext();
            return db.Companies.Where(c => c.Restaurants.Any(r => r.Areas.Any(a => a.Id == id)));
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
            return db.Advertises.Where(a => a.LunchArea.Id == areaId);
        }
    }
}