using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models;
using WebCSharp.Models.EntityFrameWork;

namespace WebCSharp.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = db.Product.OrderBy(x => x.Id);
            //var items = db.Product.ToList();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Detail(string slug,int id)
        {
            var item = db.Product.Find(id);
            return View(item);
        }
        public ActionResult ProductCategory(string slug, int id)
        {
            var items = db.Product.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.CategoryId == id).ToList();
            }
            var cate = db.Product.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Category.Name;
            }
            ViewBag.CateId = id;
            

            return View(items);
        }
        public ActionResult ProductBrand(string slug, int id)
        {
            var items = db.Product.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.BrandId == id).ToList();
            }
            var brand = db.Product.Find(id);
            if (brand != null)
            {
                ViewBag.BrandName = brand.Brand.Name;
            }
            ViewBag.BrandName = id;


            return View(items);
        }
        public ActionResult Partial_ItemsByCateId() 
        {
        var items=db.Product.Where(x=>x.Status).Take(5).ToList();
        return PartialView(items);
        }
        public ActionResult Partial_ItemsByHot()
        {
            var items = db.Product.Where(x => x.Status).Take(5).ToList();
            return PartialView(items);
        }
        //public ActionResult Partial_ItemsBySale()
        //{
        //    DateTime currentDate = DateTime.Now;

        //    var productsOnSale = db.ProductSales
        //        .Where(ps => ps.StartDate <= currentDate && (ps.EndDate == null || ps.EndDate >= currentDate))
        //        .Select(ps => ps.Product)
        //        .ToList();

        //    return PartialView(productsOnSale);
        //}
        //public ActionResult SaleProducts()
        //{
        //    DateTime currentDate = DateTime.Now;

        //    var productsOnSale = db.ProductSale.Where(ps => ps.StartDate <= currentDate && (ps.EndDate == null || ps.EndDate >= currentDate)).Take(100).ToList();

        //    return PartialView("_SaleProducts", productsOnSale);
        //}


    }
}