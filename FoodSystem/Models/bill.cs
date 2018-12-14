using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class bill
    {
        [Key]
        [ForeignKey("order")]
        public int billID { get; set; }
        public string paymentmode { get; set; }
        public int amount { get; set; }
        public virtual order order { get; set; }
    }
}