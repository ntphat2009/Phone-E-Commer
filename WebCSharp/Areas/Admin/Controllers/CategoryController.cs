using Microsoft.Ajax.Utilities;
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
	public class CategoryController : Controller
	{
		private ApplicationDbContext _dbConect = new ApplicationDbContext();
		// GET: Admin/Category
		public ActionResult Index(string Searchtext, int? page)
		{
			var pageSize = 6;
			if (page == null)
			{
				page = 1;
			}
			IEnumerable<Category> items = _dbConect.Category.OrderBy(x => x.Create_at);
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
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Add(Category model)
		{
			if (ModelState.IsValid)
			{
				model.Create_at = DateTime.Now;
				model.Update_at = DateTime.Now;

				model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
				_dbConect.Category.Add(model);
				_dbConect.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(model);
		}

		public ActionResult Edit(int id)
		{
			var item = _dbConect.Category.Find(id);
			return View(item);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Category model)
		{
			if (ModelState.IsValid)
			{
				_dbConect.Category.Attach(model);
				model.Update_at = DateTime.Now;
				model.Create_at = DateTime.Now;


				model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
				_dbConect.Entry(model).State = System.Data.Entity.EntityState.Modified;
				_dbConect.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(model);
		}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			var item = _dbConect.Category.Find(id);
			if (item != null)
			{
				_dbConect.Category.Remove(item);
				_dbConect.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		public ActionResult Show(int id)
		{
			var item = _dbConect.Category.Find(id);
			return View(item);
		}
		public ActionResult Status(int id)
		{
			var item = _dbConect.Category.Find(id);
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
						var obj = _dbConect.Category.Find(Convert.ToInt32(item));
						_dbConect.Category.Remove(obj);
						_dbConect.SaveChanges();
					}
				}

				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}