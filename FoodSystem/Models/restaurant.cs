using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class restaurant
    {
        [Key]
        public int restaurantID { get; set; }
        public string restaurant_Name { get; set; }
        public string restaurant_Address { get; set; }

        public virtual manager manager { get; set; }

        public virtual ICollection<category> categories { get; set; }

        public virtual ICollection<menu> menu { get; set; }
    }
}