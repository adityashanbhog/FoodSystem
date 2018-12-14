using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class restaurant_category
    {
        [Key]
        [Column(Order = 1)]
        public int restaurantID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int categoryID { get; set; }

        public virtual restaurant restaurants { get; set; }
        public virtual category category { get; set; }
    }
}