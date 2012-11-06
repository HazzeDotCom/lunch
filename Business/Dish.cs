using System;

namespace Business
{
    public class Dish : Entity
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public virtual DishType DishType { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public KitchenType KitchenType { get; set; }
    }
}
