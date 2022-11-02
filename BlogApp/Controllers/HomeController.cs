using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
   
    public class HomeController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ArticleList()
        {
            var data = dbentities.Articles.ToList();
            return View("_ArticleList", data);
        }
        public PartialViewResult _PopularArticles()
        {
            //Son 3 makaleyi getircek
            var model = dbentities.Articles.OrderByDescending(x=>x.UploadDate).Take(3).ToList();  //eklenme tarihine göre tersten sıralar
            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}