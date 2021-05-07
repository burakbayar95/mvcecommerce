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
    public class OrderController : BControllerBase
    {
        // GET: Order
        [Route("siparisver")]
        public ActionResult AdressList()
        {
           
            var db = new BurakDB();
            var data = db.Adresses.Where(x => x.UserID == LoginUserID).ToList();


            return View(data);
        }

        public ActionResult CreateUserAdress()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateUserAdress(UserAdress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = LoginUserID;
            entity.IsActive = true;
            entity.UserID = LoginUserID;
            var db = new BurakDB();
            db.Adresses.Add(entity);
            db.SaveChanges();

            return RedirectToAction("AdressList");

        }
        public ActionResult CreateOrder(int id)
        {
            var db = new BurakDB();

            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();

            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusID = 6;
            order.TotalProductPrice = sepet.Sum(x => x.Product.Price);
            order.TotalTaxPrice = sepet.Sum(x => x.Product.Tax);
            order.TotalTaxPrice = (order.TotalProductPrice * 18 / 100);
           
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotalProductPrice - order.TotalDiscount + order.TotalTaxPrice;
            order.UserAdressID = id;
            order.UserID = LoginUserID;
            order.OrderProducts = new List<OrderProduct>();


            foreach (var item in sepet)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity
                });
                db.Baskets.Remove(item);//sepetten atıyoruz siparişleri

            }
            db.Orders.Add(order);

            db.SaveChanges();
            
            return RedirectToAction("Detail", new { id = order.ID });
        }
        public ActionResult Detail(int id)
        {
            var db = new BurakDB();
            var data = db.Orders.Include("OrderProducts").Include("OrderProducts.Product").Include("OrderPayments").Include("Status").Include("UserAdress").Where(x => x.ID == id).FirstOrDefault();
            return View(data);
           
        }

        [Route("siparislerim")]
        public ActionResult Index()
        {
            var db= new BurakDB();
            var data = db.Orders.Include("Status").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
            //include inner join gibi
        }
        public ActionResult Pay(int id)
        {
            var db = new BurakDB();
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.StatusID = 11;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.ID });

        }
    }
}