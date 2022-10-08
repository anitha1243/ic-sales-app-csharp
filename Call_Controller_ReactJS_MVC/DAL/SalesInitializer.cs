using IC_MVP_Project_Task1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IC_MVP_Project_Task1.DAL
{
    public class SalesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            var customers = new List<Customer>
            {
            new Customer{Name="Carson",Address="Alexander"},
            new Customer{Name="Meredith",Address="Alonso"},
            new Customer{Name="Arturo",Address="Anand"},
            new Customer{Name="Gytis",Address="Barzdukas"},
            new Customer{Name="Yan",Address="Li"},
            new Customer{Name="Peggy",Address="Justice"},
            new Customer{Name="Laura",Address="Norman"},
            new Customer{Name="Nino",Address="Olivetto"}
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            var products = new List<Product>
            {
            new Product{Name="Chemistry",Price=3,},
            new Product{Name="Microeconomics",Price=3,},
            new Product{Name="Macroeconomics",Price=3,},
            new Product{Name="Calculus",Price=4,},
            new Product{Name="Trigonometry",Price=4,},
            new Product{Name="Composition",Price=3,},
            new Product{Name="Literature",Price=4,}
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            var stores = new List<Store>
            {
            new Store{Name="Carson",Address="Alexander"},
            new Store{Name="Meredith",Address="Alonso"},
            new Store{Name="Arturo",Address="Anand"},
            new Store{Name="Gytis",Address="Barzdukas"},
            new Store{Name="Yan",Address="Li"},
            new Store{Name="Peggy",Address="Justice"},
            new Store{Name="Laura",Address="Norman"},
            new Store{Name="Nino",Address="Olivetto"}
            };

            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();
            var sales = new List<Sale>
            {
            new Sale{CustomerID=1,StoreID=1,ProductID=1,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=2,StoreID=3,ProductID=2,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=3,StoreID=4,ProductID=3,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=4,StoreID=5,ProductID=4,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=5,StoreID=6,ProductID=5,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=6,StoreID=7,ProductID=6,DateSold=DateTime.Parse("2005-09-01")},
            new Sale{CustomerID=7,StoreID=8,ProductID=7,DateSold=DateTime.Parse("2005-09-01")}            
            };
            sales.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();
        }
    }
}