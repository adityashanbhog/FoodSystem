using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class customer
    {
        [Key]
        public int customerID { get; set; }
        public string customer_Name { get; set; }
      //  public string customer_Address { get; set; }
        public string email { get; set; }
        //public string Mobile { get; set; }

        public virtual ICollection<order> orders { get; set; }
    }
}