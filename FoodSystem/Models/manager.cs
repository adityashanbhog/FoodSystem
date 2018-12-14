using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class manager
    {
        [Key]
        [ForeignKey("restaurant")]
        public int managerID { get; set; }
        public string manager_Name { get; set; }
       // public string manager_Address { get; set; }
        public string email { get; set; }
        //public string mobile { get; set; }

        public virtual restaurant restaurant { get; set; }
    }
}