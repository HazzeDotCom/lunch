using System.Collections.Generic;
using System.Linq;
using Business;
using Models;

namespace Lunchsajten.Service
{
    public class CompanyService
    {
        public IEnumerable<CompanyViewModel> GetCompaniesAll()
        {
            return CompanyManager.GetCompaniesAll().Select(CreateViewModel);
        }

        public IEnumerable<CompanyViewModel> GetCompaniesByLunchArea(long id)
        {
            return CompanyManager.CompaniesByLunchArea(id).Select(CreateViewModel);
        }

        public CompanyViewModel CreateViewModel(Company c)
        {
            return new CompanyViewModel
                       {
                           CompanyName = c.Name,
                           //Box = c.Adress.Box, 
                           //LunchareaName = c.City.Name,
                           // PostCode = c.Adress.PostCode, Email = c.Email, Url = c.Url,
                           //Street = c.Adress.Street, EniroId = c.EniroId, 
                           Id = c.Id,
                           Information = c.Information,
                           //Notes = c.Notes, 
                           Organisationnr = c.Organisationnr,
                           Latitude = c.Latitude,
                           Longitude = c.Longitude,
                           AddsCount = c.Advertises.Count,
                           RestuarantsCount = c.Restaurants.Count
                       };
        }
    }
}