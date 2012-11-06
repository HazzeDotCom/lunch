using System.Collections.Generic;
using System.Web.Mvc;

namespace Models
{
    public class AdminModel
    {
        public string Tab { get; set; }
        public long LunchAreaId { get; set; }
        public string SearchString { get; set; }
        public IEnumerable<RestaurantViewModel> Restaurants { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        public IEnumerable<LunchAreaViewModel> LunchAreas { get; set; }
        public CompanyCreateModel CompanyCreateModel { get; set; }
        public string Partial { get; set; }
        public string ErrorMsg { get; set; }
        public IEnumerable<SelectListItem> SelectlistItemsLunchAreas { get; set; }
    }
}

