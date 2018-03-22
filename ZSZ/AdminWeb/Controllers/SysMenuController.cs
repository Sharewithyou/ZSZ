using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;
using Newtonsoft.Json;

namespace AdminWeb.Controllers
{
    public class SysMenuController : Controller
    {
        public ISysMenuService SysMenuService { get; set; }

        public SysMenuController(ISysMenuService sysMenuService)
        {
            this.SysMenuService = sysMenuService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenuTreeNodeData()
        {
            var result = SysMenuService.GetMenuTreeNodeData();
            return Json(result);
        }

        public ActionResult GetMenuTreeNodeById(int id = 0)
        {
            var result = SysMenuService.GetMenuTreeNodeById(id);
            return Json(result);
        }
    }
}