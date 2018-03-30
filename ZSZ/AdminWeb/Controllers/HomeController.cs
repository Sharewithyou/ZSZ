using AdminWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
    [Description(Name = "系统首页")]
    public class HomeController : Controller
    {

        [Description(Name = "浏览")]
        // GET: Home
        public ActionResult Index()
        {
            var userId = Session["LoginUserId"];
            if (userId == null)
            {
                return Redirect("/login/index");
            }
            return View();
        }
    }
}