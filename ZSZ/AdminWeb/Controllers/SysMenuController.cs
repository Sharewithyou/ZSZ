using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;

namespace AdminWeb.Controllers
{
    public class SysMenuController : Controller
    {
        private ISysMenuService SysMenuService { get; set; }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetMenuTreeNodeData()
        {
            var result = SysMenuService.GetMenuTreeNodeData();
            return Json(result);
        }
    }
}