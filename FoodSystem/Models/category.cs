using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class category
    {
        [Key]
        public int categoryID { get; set; }
        public string category_Name { get; set; }

        public virtual ICollection<restaurant> restaurants { get; set; }

        public virtual ICollection<menu> menus { get; set; }
    }
}