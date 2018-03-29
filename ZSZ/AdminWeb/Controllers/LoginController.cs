using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminWeb.App_Start;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Model.Model;
using ZSZ.Model.Model.Request;

namespace AdminWeb.Controllers
{
    public class LoginController : Controller
    {

        public ILoginService LoginService { get; set; }

        public LoginController(ILoginService service)
        {
            this.LoginService = service;
        }

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

        [Description(Name = "提交登陆")]
        public ActionResult SubmitLogin(LoginRequest request)
        {
            if (!string.Equals(request.VerifyCode, (string)TempData["verifyCode"], StringComparison.OrdinalIgnoreCase))
            {
                return Json(new MsgResult() { IsSuccess = false, Message = "验证码错误" });
            }
            else
            {
                MsgResult result = LoginService.CheckLogin(request);
                if (result.IsSuccess)
                {
                    Session["LoginUserId"] = result.Data;
                }
                return Json(result);
            }

        }
    }
}