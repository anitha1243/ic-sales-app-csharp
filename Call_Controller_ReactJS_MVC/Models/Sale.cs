using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IC_MVP_Project_Task1.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int StoreID { get; set; }
        public int ProductID { get; set; }
        public DateTime DateSold { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}