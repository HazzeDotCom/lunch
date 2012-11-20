using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
    public static class CompanyManager
    {
        public static IEnumerable<Company> GetCompaniesAll()
        {
            var db = new DataContext();
            return db.Companies.OrderBy(o => o.Name);
        }
        
        public static IEnumerable<Company> CompaniesByLunchArea(long id)
        {
            var db = new DataContext();
            return db.Companies.Where(c => c.Restaurants.Any(r => r.Areas.Any(a => a.Id == id)));
        }

        public static long CreateCompany(CompanyCreateModel createModel)
        {
            var db = new DataContext();
            var c = new Company(createModel.IsRestaurant)
                        {
                            Name = createModel.CompanyName,
                            Organisationnr = createModel.Organisationnr,
                            Information = createModel.Information,
                            Notes = createModel.Notes,
                            Latitude = createModel.Latitude,
                            Longitude = createModel.Longitude,
                            EniroId = createModel.EniroId,
                            Email = createModel.Email,
                            Url = createModel.Url,
                            //PhoneNumbers = model.PhoneNumbers.Select(p => new PhoneNumber {
                            //    Number = p.Number,
                            // Type = (PhoneNumberType) p.Type
                            // }).ToList(),
                            Adress = new Adress
                                         {
                                             PostCode = createModel.PostCode,
                                             Street = createModel.Street,
                                             PostArea = createModel.PostArea
                                         }
                        };

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

        public static bool EniroIdExists(int eniroId)
        {
            var db = new DataContext();
            return db.Companies.Any(c => c.EniroId.Equals(eniroId));
        }

        public static long CreateCompany(Company c)
        {
            using(var db = new DataContext()){
                db.Companies.Add(c);
                db.SaveChanges();
            }
            return c.Id;
        }

        
    }
}