using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class Company : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Organisationnr { get; set; }
        public int EniroId { get; set; }
        public string Information { get; set; }
        public virtual Adress Adress { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string MapUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Advertise> Advertises  { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public Company()
        {
            Advertises = new List<Advertise>();
        }

        public Company(bool isRestaurant)
        {
            if(isRestaurant)
                this.Restaurants = new List<Restaurant>();
        }
    }
}
