using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models;

namespace WebCSharp.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db=new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Menus.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop", items);
        }
        public ActionResult MenuCategory()
        {
            var items=db.Category.OrderBy(x=> x.Sort_Order).ToList();
            return PartialView("_MenuCategory",items);
        }
        public ActionResult MenuCategoryProduct(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.Category.OrderBy(x => x.Sort_Order).ToList();
            return PartialView("_MenuCategoryProduct", items);
        }
        public ActionResult MenuBrandProduct(int? id)
        {
            if (id != null)
            {
                ViewBag.BrandId = id;
            }
            var items = db.Brand.OrderBy(x => x.Sort_Order).ToList();
            return PartialView("_MenuBrandProduct", items);
        }
    }
}