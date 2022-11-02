using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class AdminController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();

        public ActionResult Index()
        {
            List<UserRole> userRoleList = new List<UserRole>();
          
            int Admin = 0;
            if (Session["SesionUserRolesList"] != null)  
            {
                userRoleList = Session["SesionUserRolesList"] as List<UserRole>;

                //Admin butona tıklamadan da url ye yazarakda sayfaya girebilir.Bunu engellemek için dbentities de kayıtlı ise şartını koy.Dbentities de bir ve birden çok kaydı varsa
                //dbde varsa giriş yapabilcek

                if (userRoleList.Count > 0)
                {
                    var dbAdmin = userRoleList.FirstOrDefault(i => i.RolesId == 2);
                    if(dbAdmin != null)
                    {
                         Admin = dbAdmin.RolesId;
                    }

                    if (Admin ==0)
                    {
                        return RedirectToAction("Index", "Home");
                    }                  
                }
               
            }else
            {
                return RedirectToAction("Login", "Users");
            }
         
            return View();
        }
        public ActionResult WriterApproved()   
        {
            var data = dbentities.Users.Where(x => x.Writer == true && x.Approved == false).ToList();   //Onaylanmayı bekleyen yazar onayları listesi
            return View(data);
        }
    }
}