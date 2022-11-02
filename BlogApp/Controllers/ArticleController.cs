
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    //[Authorize]   // her actiona izin gerekli oluyor
    public class ArticleController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();

        //[AllowAnonymous]   //Tüm kullanıcılar girebilir
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        public ActionResult ArticleDetail(int? id)
        {
            Articles model = new Articles();

            if (id.HasValue)
            {
                model = dbentities.Articles.FirstOrDefault(x => x.Id == id);

            }
            else
            {
                RedirectToAction("/Index");
            }

            return View(model);

        }

        [Authorize(Roles="Admin")]  

        public ActionResult ArticleAdd()
        {
            return View();
        }
    }
}