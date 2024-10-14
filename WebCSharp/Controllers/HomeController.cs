using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using WebCSharp.Models;

namespace WebCSharp.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SliderTop()
        {
            var items = db.Sliders.OrderBy(x => x.Position).ToList();
            return PartialView("_SliderTop", items);
        }
        public ActionResult Banner()
        {
            var items = db.Brand.OrderBy(x => x.Sort_Order).ToList();
            return PartialView("_Banner", items);
        }
        public ActionResult Blogs()
        {
            var items = db.Sliders.OrderBy(x => x.Position).ToList();
            return PartialView("_Blogs", items);
        }
    }
}