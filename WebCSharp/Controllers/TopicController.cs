using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models;

namespace WebCSharp.Controllers
{
    public class TopicController : Controller
    {
        // GET: Post
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult TopicHome()
        //{
        //    var items = db.Topics.OrderBy(x => x.).ToList();
        //    return PartialView("_MenuTop", items);
        //}
        //public ActionResult MenuCategory()
        //{
        //    var items = db.Categories.OrderBy(x => x.Sort_Order).ToList();
        //    return PartialView("_MenuCategory", items);
        //}
    }
}