using Burak.Eticaret.Core.Model;
using System.Linq;
using System.Web.Mvc;





namespace Burak.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        BurakDB db = new BurakDB();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
          var data=  db.Users.Where(x => x.Email == Email && x.Password==Password&&x.IsActive==true&&x.IsAdmin==true).ToList();
            if (data.Count==1)
            {
                //doğru giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();

                return Redirect("/admin");


            }
            else
            {
                //hatalı giriş
                return View();

            }

            return View();
        }
    }
}