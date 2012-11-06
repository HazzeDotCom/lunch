using System.Collections.Generic;

namespace Models
{
    public class CompanyModel
    {
        public long? Id { get; set; }
        public string CompanyName { get; set; }
        public string Organisationnr { get; set; }
        public string Information { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string LunchareaName { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string PostArea { get; set; }
        public string Box { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int EniroId { get; set; }
        public string Notes { get; set; }
    }

    public class CompanyCreateModel : CompanyModel
    {
        public long LunchAreaId { get; set; }
        public bool IsRestaurant { get; set; }
        public string CreateMsg { get; set; }

        //  public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
    
    public class LunchAreaCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public long Id { get; set; }
    }

    public class CompanyViewModel : CompanyModel
    {
        public new long Id { get; set; }
        //public AdressViewModel Adress { get; set; }
        public IEnumerable<PhoneNumberModel> PhoneNumbers { get; set; }
        public int RestuarantsCount { get; set; }
        public int AddsCount { get; set; }
    }
}