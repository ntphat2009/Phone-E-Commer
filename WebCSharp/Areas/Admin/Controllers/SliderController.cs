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
    public class SliderController : Controller
    {
        // GET: Admin/Slider
        private ApplicationDbContext _dbConect = new ApplicationDbContext();

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Slider> items = _dbConect.Sliders.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Name.Contains(Searchtext) || x.Link.Contains(Searchtext));
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Slider model)
        {
            if (ModelState.IsValid)
            {

                model.Update_at= DateTime.Now;
                model.Create_at= DateTime.Now;
                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Sliders.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.Sliders.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Sliders.Attach(model);
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;


                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Sliders.Find(id);
            if (item != null)
            {
                _dbConect.Sliders.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Sliders.Find(id);
            return View(item);
        }
        public ActionResult Status(int id)
        {
            var item = _dbConect.Sliders.Find(id);
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
                        var obj = _dbConect.Sliders.Find(Convert.ToInt32(item));
                        _dbConect.Sliders.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}