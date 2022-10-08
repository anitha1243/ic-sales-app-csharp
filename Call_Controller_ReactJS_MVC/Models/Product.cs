using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IC_MVP_Project_Task1.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}