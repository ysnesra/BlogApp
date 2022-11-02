using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class WriterController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WriterDo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterDo(Users uservalue, string rdMan, string rdWoman)
        {
            if (string.IsNullOrEmpty(uservalue.UserName) && string.IsNullOrEmpty(uservalue.Password) && string.IsNullOrEmpty(uservalue.NameSurname) && string.IsNullOrEmpty(uservalue.Email))
            {
                ModelState.AddModelError("", "Kullanıcı Adı Zorunlu");
                ModelState.AddModelError("", "Parola Zorunlu");
                ModelState.AddModelError("", "Ad soyad Zorunlu");
                ModelState.AddModelError("", "Mail adresi Zorunlu");
                return View();
            }

            if (!string.IsNullOrEmpty(rdMan))
            {
                uservalue.Gender = true;
            }
            else
            {
                uservalue.Gender = false;
            }


            uservalue.Writer = true;      //Kullanıcı Yazardır
            uservalue.Approved = false;   //Admin tarafından İlk başta Yazar olduğu onaylanmamış.Admin onaylarsa true olsun
            uservalue.Active = true;
            uservalue.CreatedDate = DateTime.Now;
            dbentities.Users.Add(uservalue);

            int UserRes = dbentities.SaveChanges();

            //Yazar butona tıklamadan da url ye yazarakda sayfaya girebilir.Bunu engellemek için dbentities de kayıtlı ise şartını koy.Dbentities de bir ve birden çok kaydı varsa
            //dbde varsa giriş yapabilcek

            if (UserRes > 0)
            {
                Roles writerRol = new Roles();
                writerRol = dbentities.Roles.FirstOrDefault(x => x.RoleName == "Writer");  
                //Önce Rol adı yazar olan ilk kişiyi Roles tablusundan çek
               
                UserRole userrol = new UserRole();  //sonra UserRole tablosundan da RolesId'sini ve Id'sini çek
                userrol.RolesId = writerRol.RolesId;
                userrol.UsersId = uservalue.Id; 

                dbentities.UserRole.Add(userrol);
                dbentities.SaveChanges();
            }
            return RedirectToAction("Index", "Home"); 

        }
    }
}