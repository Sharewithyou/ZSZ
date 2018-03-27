﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult SubmitLogin(LoginRequest request)
        {
            if (request.VerifyCode != (string) TempData["verifyCode"])
            {
                return Json(new MsgResult() {IsSuccess = false, Message = "验证码错误"});
            }
            else
            {
                MsgResult result = LoginService.CheckLogin(request);
            }
            return null;
        }
    }
}