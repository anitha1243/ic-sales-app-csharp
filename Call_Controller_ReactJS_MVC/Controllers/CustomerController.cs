using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using IC_MVP_Project_Task1.DAL;
using IC_MVP_Project_Task1.Models;
using NLog;

namespace IC_MVP_Project_Task1.Controllers
{
    public class CustomerController : Controller
    {
        private SalesContext db = new SalesContext();

        // GET: Customer
        [HttpGet]
        public JsonResult Index()
        {
            var dataSourceList = new List<Customer>();

            for(int i = 0; i < db.Customers.ToList().Count(); i++)
            {
                dataSourceList.Add(new Customer
                {
                    ID = db.Customers.ToList()[i].ID,
                    Name = db.Customers.ToList()[i].Name,
                    Address = db.Customers.ToList()[i].Address
                });
            }            

            // convert it to array
            var dataSource = dataSourceList.ToArray();
            return Json(dataSource, JsonRequestBehavior.AllowGet);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult CreateCustomer(string name, string address)
        {
            Customer customer = new Customer
            {
                Name = name,
                Address = address
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return Json(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public int EditCustomer(int ID, string Name, string Address)
        {
            var name = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 20)
            {
                Value = Name
            };

            var address = new SqlParameter("@Address", System.Data.SqlDbType.VarChar, 20)
            {
                Value = Address
            };

            var id = new SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                Value = ID
            };
            var sql = @"Update [Customer] SET Name = @name, Address = @address WHERE ID = @id";
            db.Database.ExecuteSqlCommand(sql, name, address, id);
            return 200;
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Json(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
