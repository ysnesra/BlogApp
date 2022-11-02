using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class CategoriController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult _Categori()
        {
            return PartialView(dbentities.Categories.ToList());
        }

        public ActionResult ArticleList(int id)
        {
            var data = dbentities.Articles.Where(x=>x.CategoriesId==id).ToList(); //Kategori Idsi kullanıcının tıkladığı id ye eşit olan Makaleleri listele
           
            return View("_ArticleList",data);   
        }
    }
}