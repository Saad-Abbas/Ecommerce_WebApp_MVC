using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garments.Models
{
    public class Orders
    {
       // public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public string shortdiscription { get; set; }
        public double Price { get; set; }
       // public string PicUrl { get; set; }

        public string producttype { get; set; }
       


    }
}