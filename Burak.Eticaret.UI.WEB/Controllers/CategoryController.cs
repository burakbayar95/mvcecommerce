using Burak.Eticaret.Core.Model;
using Burak.Eticaret.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burak.Eticaret.UI.WEB
{ 
    public class CategoryController : BControllerBase
    {
    
        // GET: Category
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim,int id)
        {
            ViewBag.IsLogin = this.IsLogin;
            var db = new BurakDB();
     var data =  db.Products.Where(x => x.IsActive == true && x.CategoryID == id).ToList();
        ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();


            return View(data);
        }
    }
}
