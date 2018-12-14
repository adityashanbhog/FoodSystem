using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class menu
    {
        [Key]
        public int menuID { get; set; }
        public string menu_Name { get; set; }
        public string price { get; set; }

        [ForeignKey("restaurant")]
        public int restaurantID { get; set; }
        public virtual restaurant restaurant { get; set; }

        [ForeignKey("category")]
        public int categoryID { get; set; }
        public virtual category category { get; set; }
    }
}