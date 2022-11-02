using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {
        BlogDbEntities2 dbentities = new BlogDbEntities2();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult Login(Users userin)       
        {


            if ((string.IsNullOrEmpty(userin.UserName)) && (string.IsNullOrEmpty(userin.Password)))
            {
                ModelState.AddModelError("", "Kullanıcı Bilgileri boş olamaz!");
                return View();
            }

            Users dbUser = dbentities.Users.FirstOrDefault(x => x.UserName == userin.UserName && x.Password == userin.Password);

            if (dbUser != null)    //Kullanıcı tablosunda ise ya yazardır yada üyedir
            {
                var UserRolesList = dbUser.UserRole.ToList();   //UserRole tablosunun verilerini liste şeklinde bir değişkene atadık
                Session["SessionUserRolesList"] = UserRolesList;    //Sessionda oluşturduğumuz "SesionUserRolesList" değişkenine role listemizi attık
                Session["SessionUserName"] = dbUser.UserName;      
                Session["SessionNameSurname"] = dbUser.NameSurname;
                Session["SessionUserId"] = dbUser.Id;


                return RedirectToAction("Index", "Home");

            }
            else
            {
                //Kullanıcı yok ise buruaya mesaj vereceğiz

                ModelState.AddModelError("", "Kullanıcı Bilgileri Hatalı!");
                return View();
        
            }
            return View();
        }


        public ActionResult Logout()   
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Users uservalue, string rdMan, string rdWoman) 
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
            if (!string.IsNullOrEmpty(rdWoman))
            {
                uservalue.Gender = false;
            }
            uservalue.Writer = false;     //Yazar- 
            uservalue.Approved = true;   
            uservalue.Active = true;   //Kullanıcı üye olmuş
            uservalue.Birthdate = uservalue.Birthdate.Value.Date; 
            uservalue.CreatedDate=DateTime.Now;  
           
            dbentities.Users.Add(uservalue);
            dbentities.SaveChanges();

            

            return RedirectToAction("Login"); //Üye olduktan sonra girişyap actionına gitsin
        }
    }
}