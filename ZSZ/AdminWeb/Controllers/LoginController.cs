using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Common;

namespace AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateVerifyCode()
        {
            string code = CaptchaHelper.CreateVerifyCode(4);
            MemoryStream ms = CaptchaHelper.CreateVerifyCodeImg(code);
            TempData["verifyCode"] = code;
            //Session["verifyCode"] = verifyCode;
            return File(ms, "image/jpeg");
        }
    }
}