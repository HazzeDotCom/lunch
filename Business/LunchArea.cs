using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class LunchArea : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Message Message { get; set; }

        /// <summary>
        /// set this through 'LunchAreaStatus
        /// </summary>
        public int Status { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public string Url { get; set; }

        public LunchAreaStatus LunchAreaStatus
        {
            get
            {
                return (LunchAreaStatus)Status;
            }
            set
            {
                Status = (int)value;
            }
        }
    }

    public enum LunchAreaStatus
    {
        New = 0,
        Active = 1,
        Inactive = 2
    }
}
