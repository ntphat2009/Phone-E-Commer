using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebCSharp.Models;
using WebCSharp.Models.EntityFrameWork;

namespace WebCSharp.Controllers
{
    public class ProductSaleController : Controller
    {
        // GET: ProductSale
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult SaleProducts()
        //{
        //    DateTime currentDate = DateTime.Now;

        //    var productsOnSale = db.ProductSales
        //        .Where(ps => ps.StartDate <= currentDate && (ps.EndDate == null || ps.EndDate >= currentDate))
        //        .Select(ps => ps.Products)
        //        .ToList();

        //    return View(productsOnSale);
        //}

       
    }
}