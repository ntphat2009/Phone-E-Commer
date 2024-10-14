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
    public class ProductImageController : Controller
    {
        private ApplicationDbContext _dbConect = new ApplicationDbContext();

        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = _dbConect.ProductImages.Where(x => x.ProductId == id).ToList();
           
            return View(items);
        }
        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            _dbConect.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                isDefault = false
            });
            _dbConect.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var items = _dbConect.ProductImages.Find(id);
            _dbConect.ProductImages.Remove(items);
            _dbConect.SaveChanges();
            return Json(new {success=true});
        }
    }
}