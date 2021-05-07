using Burak.Eticaret.Core.Model;
using Burak.Eticaret.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Burak.Eticaret.UI.WEB.Controllers
{
    public class ProductController : BControllerBase
    {
        // GET: Product
        [Route("urun/{title}/{id}")]
        public ActionResult Detail(string title,int id)
        {
            ViewBag.IsLogin = this.IsLogin;
            var db = new BurakDB();
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(prod);
        }
    }
}