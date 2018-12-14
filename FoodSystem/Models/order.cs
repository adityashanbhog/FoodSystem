using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class order
    {
        [Key]
        public int orderID { get; set; }

        [ForeignKey("customer")]
        public int customerID { get; set; }

        public virtual customer customer { get; set; }

        public virtual bill bill { get; set; }

        public virtual ICollection<detail> details { get; set; }
    }
}