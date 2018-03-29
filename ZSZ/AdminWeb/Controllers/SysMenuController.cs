using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;
using Newtonsoft.Json;
using log4net;
using AdminWeb.AutofacFolder;
using ZSZ.Model.Model;
using AdminWeb.App_Start;

namespace AdminWeb.Controllers
{
    [Description(Name = "菜单管理")]
    public class SysMenuController : Controller
    {
        public ISysMenuService SysMenuService { get; set; }

        public SysMenuController(ISysMenuService sysMenuService)
        {
            this.SysMenuService = sysMenuService;
        }

        [Description(Name = "浏览")]     
        public ActionResult Index()
        {
            return View();
        }

        [Description(Name = "增加菜单页")]
        public ActionResult AddMenuPage(int id = 0)
        {
            if (id < 0)
            {
                return Redirect("~/404.html");
            }
            var result = SysMenuService.GetMenuTreeNodeById(id);
            if (result.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<SysMenus>(result.Data);
                return View(model);
            }
            else
            {
                return Redirect("~/404.html");
            }

        }



        [Description(Name = "修改菜单页")]
        public ActionResult UpdateMenuPage(int id = 0)
        {
            if (id < 0)
            {
                return Redirect("~/404.html");
            }
            var result = SysMenuService.GetMenuTreeNodeById(id);
            if (result.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<SysMenus>(result.Data);
                return View(model);
            }
            else
            {
                return Redirect("~/404.html");
            }
        }

        /// <summary>
        /// 获取菜单节点树数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenuTreeNodeData()
        {
            var result = SysMenuService.GetMenuTreeNodeData();
            return Json(result);
        }

        /// <summary>
        /// 获取菜单子节点数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMenuTreeNodeById(int id = 0)
        {
            var result = SysMenuService.GetMenuTreeChildNodeListById(id);
            return Json(result);
        }


        [Description(Name = "增加菜单")]       
        public ActionResult AddMenuNode(SysMenus node)
        {
            var result = SysMenuService.AddMenuNode(node);
            return Json(result);
        }
    
        [Description(Name = "修改菜单")]
        public ActionResult UpdateMenuNode(SysMenus node)
        {
            var result = SysMenuService.UpdateMenuNode(node);
            return Json(result);
        }

        [Description(Name = "删除菜单")]
        public ActionResult MarkDeleteNode(SysMenus node)
        {
            var result = SysMenuService.MarkDeleteNode(node);
            return Json(result);
        }



    }
}