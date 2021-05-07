using Burak.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Burak.Eticaret.UI.WEB.Controllers.Base
{
    public class BControllerBase:Controller

    {
        public bool IsLogin { get; private set; }//dışarıdan veri atanamasın/sadece bu controller üzerinden
        public int LoginUserID { get;private set; }//giriş yapılan id
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            //
            //Session["LoginUserID"] = users.FirstOrDefault().ID;
            // Session["LoginUser"] = users.FirstOrDefault();

            if (requestContext.HttpContext.Session["LoginUserID"]!=null)
            {
                //kullanıcı giriş yapmış
                IsLogin = true;
                LoginUserID =(int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];

            }

            base.Initialize(requestContext);
        }
    }
}