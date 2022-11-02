using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class TagController : Controller
    {

        BlogDbEntities2 dbentities = new BlogDbEntities2();
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult _Tag()
        {
            return PartialView(dbentities.Tags.ToList());
        }

        public ActionResult ArticleList(int id)
        {
            var data = dbentities.Articles.Where(x => x.Tags.Any(y => y.Id == id)).ToList();   //Any methodu Where yerine kullandık.Any içinde yaptığı şartı sağlıyorsa true dönmesini sağlar

            return View("_ArticleList", data);  
        }
    }
}