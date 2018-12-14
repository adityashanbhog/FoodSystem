using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodSystem.Models;

namespace FoodSystem
{
    public class p1
    {
        public string name { get; set; }
        public IEnumerable<Models.menu> value { get; set; }
    }
}