using System;
using System.Collections.Generic;

namespace Models
{
    public class LunchAreaViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        //public DateTime Added { get; set; }
        public int RestaurantsCount { get; set; }
        public int AdvertisesCount { get; set; }
        public string Url { get; set; }
    }
   
}