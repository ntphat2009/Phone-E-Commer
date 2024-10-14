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
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private ApplicationDbContext _dbConect = new ApplicationDbContext();
        
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Order> items = _dbConect.Orders.OrderBy(x => x.Create_at);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Name.Contains(Searchtext) || x.Phone.Contains(Searchtext));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.User = new SelectList(_dbConect.Users.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;


                _dbConect.Orders.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(_dbConect.Users.ToList(), "Id", "Name");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.Orders.Find(id);
            ViewBag.User = new SelectList(_dbConect.Users.ToList(), "Id", "Name");

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Orders.Attach(model);
                model.Update_at = DateTime.Now;
                model.Create_at = DateTime.Now;



                _dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User = new SelectList(_dbConect.Users.ToList(), "Id", "Name");

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Orders.Find(id);
            if (item != null)
            {
                _dbConect.Orders.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Orders.Find(id);
            ViewBag.User = new SelectList(_dbConect.Users.ToList(), "Id", "Name");

            return View(item);
        }
        public ActionResult Status(int id)
        {
            var item = _dbConect.Orders.Find(id);
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
                        var obj = _dbConect.Orders.Find(Convert.ToInt32(item));
                        _dbConect.Orders.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}