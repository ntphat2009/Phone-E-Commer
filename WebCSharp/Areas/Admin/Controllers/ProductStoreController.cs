using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models.EntityFrameWork;
using WebCSharp.Models;

namespace WebCSharp.Areas.Admin.Controllers
{
    public class ProductStoreController : Controller
    {
        // GET: Admin/ProductStore
        private ApplicationDbContext _dbConect = new ApplicationDbContext();

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<ProductStore> items = _dbConect.ProductStore.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Product.Name.Contains(Searchtext));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            var product = _dbConect.Product.FirstOrDefault();
            ViewBag.ProductName = product.Name;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductStore model)
        {
            if (ModelState.IsValid)
            {
                model.Update_at = DateTime.Now;
                model.Create_at = DateTime.Now;
                _dbConect.ProductStore.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.ProductStore.Find(id);
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductStore model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.ProductStore.Attach(model);

                model.Update_at = DateTime.Now;
                model.Create_at = DateTime.Now;


                _dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(_dbConect.Product.ToList(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.ProductStore.Find(id);
            if (item != null)
            {
                _dbConect.ProductStore.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.ProductStore.Find(id);
            var product = _dbConect.Product.FirstOrDefault();
            ViewBag.ProductName = product.Name;
            return View(item);
        }
        //public ActionResult Status(int id)
        //{
        //    var item = _dbConect.ProductStores.Find(id);
        //    if (item != null)
        //    {
        //        item.Status = !item.Status;
        //        _dbConect.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        _dbConect.SaveChanges();
        //        return Json(new { success = true, Status = item.Status });
        //    }
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
                        var obj = _dbConect.ProductStore.Find(Convert.ToInt32(item));
                        _dbConect.ProductStore.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}