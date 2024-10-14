using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models.EntityFrameWork;
using WebCSharp.Models;
using WebCSharp.Models.ViewModel;

namespace WebCSharp.Areas.Admin.Controllers
{
    public class ProductSaleController : Controller
    {
        // GET: Admin/ProductSale
        private ApplicationDbContext _dbConect = new ApplicationDbContext();

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            var product = _dbConect.Product.FirstOrDefault();
            ViewBag.ProductName = product.Name;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<ProductSale> items = _dbConect.ProductSale.OrderBy(x => x.Id);
            //if (!string.IsNullOrEmpty(Searchtext))
            //{
            //    items = items.Where(x => x..Contains(Searchtext) || ViewBag.ProductName.Contains(Searchtext));
            //}

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductSale model)
        {
            if (ModelState.IsValid)
            {


                model.Update_at = DateTime.Now;
                model.Create_at = DateTime.Now;
                _dbConect.ProductSale.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.ProductSale.Find(id);
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductSale model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.ProductSale.Attach(model);

                model.Update_at = DateTime.Now;
                model.Create_at = DateTime.Now;
                ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");

                _dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.ProductSale.Find(id);
            if (item != null)
            {
                _dbConect.ProductSale.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.ProductSale.Find(id);
            return View(item);
        }
        //public ActionResult Status(int id)
        //{
        //    var item = _dbConect.ProductSales.Find(id);
        //    if (item != null)
        //    {
        //        item.Status = !item.Status;
        //        _dbConect.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        _dbConect.SaveChanges();
        //        return Json(new { success = true, Status = item.Status });
        //    }
        //    var product = _dbConect.Products.FirstOrDefault();
        //    ViewBag.ProductName = product.Name;
        //    return Json(new { success = false });
        //}
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {

            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = _dbConect.ProductSale.Find(Convert.ToInt32(item));
                        _dbConect.ProductSale.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        //public ActionResult GetProductSaleByProductId(int productId)
        //{
        //    var result = new ProductSaleVM
        //    {
        //        Product = _dbConect.Product.Find(productId),
        //        ProductSale = _dbConect.ProductSale.Where(x => x.ProductId == productId).FirstOrDefault(),
        //    };

        //    result.Modification = result.Product.CategoryId == 30 ? "xin chao iphone" : "";

        //    return View(result);
        //}
    }
}