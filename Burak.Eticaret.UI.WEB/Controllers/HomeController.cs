using Burak.Eticaret.Core.Model;
using Burak.Eticaret.Core.Model.Entity;
using Burak.Eticaret.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burak.Eticaret.UI.WEB.Controllers
{
    public class HomeController : BControllerBase
    {
        BurakDB db = new BurakDB();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;//controllerdan gelen islogin
            
          
          var data = db.Products.OrderByDescending(x => x.CreateDate).Take(10).ToList();


            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);


        }

       



        [Route("uye-giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("uye-giris")]
        public ActionResult Login(string Email,string Password)
        {
           
            var users = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive == true && x.IsAdmin == false).ToList();
            if (users.Count==1)

            {
                //giriş tamam
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");

            }

            else
               {
                //sayfa arası veri taşıma
                ViewBag.Error = "Hatalı Kullanıcı Adı veya Şifre";

                return View();
            }
            
            
        }

        [Route("uye-kayit")]
        public ActionResult CreateUser()
        {
            return View();

        }

        [HttpPost]
        [Route("uye-kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;//uye eklediğimiz için
                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");//anasayfa
                //return View();
            }
            catch (Exception ex)
            {
                return View();
                
            }
           

        }


    }
}