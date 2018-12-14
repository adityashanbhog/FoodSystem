using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSystem.Models
{
    public class detail
    {
        [Key]
        public int detailD { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        [ForeignKey("order")]
        public int orderID { get; set; }

        public virtual order order { get; set; }
    }
}