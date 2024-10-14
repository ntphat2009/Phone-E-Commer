using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebCSharp.Models;
using WebCSharp.Models.EntityFrameWork;


namespace WebCSharp.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _dbConect = new ApplicationDbContext();
        // GET: Admin/Menu

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Menu> items = _dbConect.Menus.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Link.Contains(Searchtext) || x.Name.Contains(Searchtext));
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
        public ActionResult Add(Menu model )
        {
            if (ModelState.IsValid)
            {
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;
               
                model.Type = model.Name;
                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Menus.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.Menus.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Menus.Attach(model);
                model.Update_at = DateTime.Now;
       
                model.Type = model.Name;
                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Entry(model).Property(x=>x.Name).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Link).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Position).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Parent_Id).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Table_Id).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Type).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Update_at).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Update_By).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Status).IsModified = true;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Menus.Find(id);
            if (item != null)
            {
                _dbConect.Menus.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Menus.Find(id);
            return View(item);
        }
        public ActionResult Status(int id)
        {
            var item = _dbConect.Menus.Find(id);
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
                        var obj = _dbConect.Menus.Find(Convert.ToInt32(item));
                        _dbConect.Menus.Remove(obj);
                        _dbConect.SaveChanges();
                    }
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
    

}