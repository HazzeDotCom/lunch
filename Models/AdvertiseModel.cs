namespace Models
{
    public class AdvertiseViewModel
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string CompanyUrl { get; set; }
    }

    public class AddsColumnRowModel
    {
        public AdvertiseViewModel First { get; set; }
        public AdvertiseViewModel Second { get; set; }
    }
}