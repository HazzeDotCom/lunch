using System;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        //public DateTime CreatedBy { get; set; }
        //public DateTime EditedBy { get; set; }
        public Entity()
        {
            Created = DateTime.Now;
            Edited = DateTime.Now;
        }
    }
}