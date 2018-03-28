using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Model.Model;

namespace AdminWeb.App_Start
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string userId = (string) filterContext.HttpContext.Session["LoginUserId"];
            if (userId == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    MsgResult result = new MsgResult();
                    result.IsSuccess = false;
                    result.Data = "/login/index";
                    result.Message = "没有登录";
                    result.MsgCode = 10001;
                    filterContext.Result = new JsonResult() {Data = result};
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Main/Login");
                }
            }
            else
            {
                //1 ,判断角色，获取所有的权限
                //2 , 判断是否包含当前的权限
            }
        }
    }
}