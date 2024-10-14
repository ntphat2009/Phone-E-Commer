using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models.EntityFrameWork;
using WebCSharp.Models;
using System.Drawing;

namespace WebCSharp.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbConect = new ApplicationDbContext();


        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = _dbConect.Product.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Slug.Contains(Searchtext) || x.Name.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.Category = new SelectList(_dbConect.Category.ToList(), "Id", "Name");
            ViewBag.Brand = new SelectList(_dbConect.Brand.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                isDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImages.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                isDefault = false


                            });
                        }
                    }
                }

                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;
                
                model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Product.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(_dbConect.Category.ToList(), "Id", "Name");
            ViewBag.Brand = new SelectList(_dbConect.Brand.ToList(), "Id", "Name");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Category = new SelectList(_dbConect.Category.ToList(), "Id", "Name");
            ViewBag.Brand = new SelectList(_dbConect.Brand.ToList(), "Id", "Name");
            var item = _dbConect.Product.Find(id);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Product.Attach(model);
                model.Update_at = DateTime.Now;


                model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(_dbConect.Category.ToList(), "Id", "Name");
            ViewBag.Brand = new SelectList(_dbConect.Brand.ToList(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Product.Find(id);
            

            if (item != null)
            {
                // Lấy ProductId của bản ghi Product sẽ bị xóa
                int productId = item.Id;

                // Xóa tất cả các ProductImage có Product_Id1 tương ứng
                //var productImagesToDelete = _dbConect.ProductImages.Where(pi => pi.Product_Id1 == productId);
                //_dbConect.ProductImages.RemoveRange(productImagesToDelete);

                _dbConect.Product.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Product.Find(id);
            return View(item);
        }
        public ActionResult Status(int id)
        {
            var item = _dbConect.Product.Find(id);
            if (item != null)
            {
                item.Status = !item.Status;
                _dbConect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _dbConect.SaveChanges();
                return Json(new { success = true, Status = item.Status });
            }
            return Json(new { success = false });
        }
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
                        var obj = _dbConect.Product.Find(Convert.ToInt32(item));
                        _dbConect.Product.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}