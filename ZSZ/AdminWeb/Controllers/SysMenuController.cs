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

namespace AdminWeb.Controllers
{
    public class SysMenuController : Controller
    {
        public ISysMenuService SysMenuService { get; set; }

        public SysMenuController(ISysMenuService sysMenuService)
        {
            this.SysMenuService = sysMenuService;
        }

        /// <summary>
        /// 菜单管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int nodeId)
        {
            return View();
        }

        /// <summary>
        /// 增加菜单页
        /// </summary>
        /// <returns></returns>
        public ActionResult AddMenuPage(int Id = 0)
        {
            if (Id < 0)
            {              
                return Redirect("~/404.html");
            }
            var result = SysMenuService.GetMenuTreeNodeById(Id);
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
        /// 修改菜单页
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateMenuPage()
        {
            return View();
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

        public ActionResult AddMenuNode(SysMenus node)
        {
            var result = SysMenuService.AddMenuNode(node);
            return Json(result);
        }

    }
}