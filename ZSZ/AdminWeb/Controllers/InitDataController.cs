﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using AdminWeb.App_Start;
using log4net;
using Newtonsoft.Json;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace AdminWeb.Controllers
{

    public class InitDataController : Controller
    {
        public IInitDataService InitDataService { get; set; }

        public ISysRoleService SysRoleService { get; set; }

        public ISysOperationService SysOperationService { get; set; }

        public ISysMenuService SysMenuService { get; set; }


        private static ILog log = LogManager.GetLogger(typeof(InitDataController));

        public InitDataController(ISysRoleService currntService, ISysOperationService sysOperationService, IInitDataService initDataService, ISysMenuService sysMenuService)
        {
            this.SysRoleService = currntService;
            this.SysOperationService = sysOperationService;
            this.InitDataService = initDataService;
            this.SysMenuService = sysMenuService;
        }

        // GET: InitData
        public ActionResult InitOperationData()
        {
            #region 重置数据

            //清空角色表
            SysRoleService.Clear(typeof(T_SysRoles).Name);

            //清空权限表
            SysOperationService.Clear(typeof(T_SysOperations).Name);

            #endregion
            using (TransactionScope ts = new TransactionScope())
            {
                #region 1 , 管理员初始化

                T_SysRoles role = new T_SysRoles();
                role.Guid = Guid.NewGuid().ToString("N");
                role.Name = "超级管理员";
                role.Description = "拥有所有的权限";
                role.CreateUser = 1;
                role.CreateTime = DateTime.Now;
                SysRoleService.AddEntity(role);

                #endregion

                #region 2 , 操作权限初始化

                //List<SysOperations> list = new List<SysOperations>();

                List<T_SysOperations> list = new List<T_SysOperations>();

                //创建控制器类型列表
                List<Type> controllerTypes = new List<Type>();

                //加载程序集  
                var assembly = Assembly.Load("AdminWeb");

                controllerTypes.AddRange(assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) & type.IsDefined(typeof(DescriptionAttribute))));

                foreach (var controller in controllerTypes)
                {
                    //var controller = assembly.GetTypes().Where(type => type.Name == itemType.Name).FirstOrDefault();

                    //获取控制器的标记属性
                    var typeName = ((DescriptionAttribute)controller.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).Name;

                    //获取所有的标记方法
                    var actions = controller.GetMethods().Where(method => method.IsDefined(typeof(DescriptionAttribute)));

                    foreach (var action in actions)
                    {
                        var attr = ((DescriptionAttribute)action.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).Name;
                        var isNotShow = ((DescriptionAttribute)action.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).IsNotShow;
                        T_SysOperations model = new T_SysOperations();
                        model.ContronllerName = controller.Name.Replace("Controller", "");
                        model.ActionName = action.Name;
                        model.TypeName = typeName;
                        model.OperateName = attr;
                        model.Guid = Guid.NewGuid().ToString("N");
                        model.CreateUser = 1;
                        model.CreateTime = DateTime.Now;
                        if (isNotShow)
                            model.IsNotShow = true;
                        list.Add(model);
                    }
                }

                MsgResult result = SysOperationService.AddRange(list);
                #endregion
            }

            return null;
        }

        public ActionResult Test()
        {

            #region 初始化菜单

            SysMenuService.Clear(typeof(T_SysMenus).Name);

            var nodes = MvcSiteMapProvider.SiteMaps.Current.FindSiteMapNodeFromKey("root").ChildNodes;
            foreach (var node in nodes)
            {
                if (!node.Clickable)
                {
                    T_SysMenus menu = new T_SysMenus();
                    menu.Guid = Guid.NewGuid().ToString("N");
                    menu.MenuName = node.Title;
                    menu.MenuUrl = "";
                    menu.ParentId = 0;
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUser = 1;
                    menu.IconFont = (string)node.Attributes["iconfont"];
                    var result = SysMenuService.AddEntity(menu);
                    if (result.IsSuccess)
                    {
                        T_SysMenus addMenu = JsonConvert.DeserializeObject<T_SysMenus>(result.Data);
                        var childNodes = node.ChildNodes;
                        List<T_SysMenus> menuList = new List<T_SysMenus>();
                        foreach (var childNode in childNodes)
                        {
                            T_SysMenus menuNew = new T_SysMenus();
                            menuNew.Guid = Guid.NewGuid().ToString("N");
                            menuNew.MenuName = childNode.Title;
                            menuNew.MenuUrl = "/" + childNode.Controller + "/" + childNode.Action;
                            menuNew.ParentId = addMenu.Id;
                            menuNew.IsLeaf = true;
                            menuNew.CreateTime = DateTime.Now;
                            menuNew.CreateUser = 1;
                            menuList.Add(menuNew);
                        }

                        var resultNew = SysMenuService.AddRange(menuList);
                    }

                }
            }

            #endregion

            #region 初始化权限操作列表

            List<T_SysOperations> list = new List<T_SysOperations>();

            //创建控制器类型列表
            List<Type> controllerTypes = new List<Type>();

            //加载程序集  
            var assembly = Assembly.Load("AdminWeb");

            controllerTypes.AddRange(assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) & type.IsDefined(typeof(DescriptionAttribute))));

            foreach (var controller in controllerTypes)
            {
                //var controller = assembly.GetTypes().Where(type => type.Name == itemType.Name).FirstOrDefault();

                //获取控制器的标记属性
                var typeName = ((DescriptionAttribute)controller.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).Name;

                //获取所有的标记方法
                var actions = controller.GetMethods().Where(method => method.IsDefined(typeof(DescriptionAttribute)));

                foreach (var action in actions)
                {
                    var attr = ((DescriptionAttribute)action.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).Name;
                    var isNotShow = ((DescriptionAttribute)action.GetCustomAttributes(typeof(DescriptionAttribute)).FirstOrDefault()).IsNotShow;
                    T_SysOperations model = new T_SysOperations();
                    model.ContronllerName = controller.Name.Replace("Controller", "");
                    model.ActionName = action.Name;
                    model.TypeName = typeName;
                    model.OperateName = attr;
                    model.Guid = Guid.NewGuid().ToString("N");
                    model.CreateUser = 1;
                    model.CreateTime = DateTime.Now;
                    if (isNotShow)
                        model.IsNotShow = true;
                    list.Add(model);
                }
            }

            #endregion

            InitDataService.InitData(list);
            return View();
        }

        public ActionResult Test1()
        {
            //log.Fatal("123456");
            //if (!log4net.LogManager.GetRepository().Configured)
            //{
            //    // log4net not configured
            //    foreach (log4net.Util.LogLog message in log4net.LogManager.GetRepository().ConfigurationMessages.Cast<log4net.Util.LogLog>())
            //    {
            //        // evaluate configuration message
            //    }
            //}

          

            return View();

        }

        public ActionResult Test2(string name)
        {
            T_SysRoles role = new T_SysRoles();
            role.Guid = Guid.NewGuid().ToString("N");
            role.Name = "超级管理员";
            role.Description = "拥有所有的权限";
            role.CreateUser = 1;
            role.CreateTime = DateTime.Now;
            SysRoleService.AddEntity(role);
            return null;
        }

        public ActionResult InitMenu()
        {           
            var nodes = MvcSiteMapProvider.SiteMaps.Current.FindSiteMapNodeFromKey("root").ChildNodes;
            foreach (var node in nodes)
            {
                if (!node.Clickable)
                {
                    T_SysMenus menu = new T_SysMenus();
                    menu.Guid = Guid.NewGuid().ToString("N");
                    menu.MenuName = node.Title;
                    menu.MenuUrl = "";
                    menu.ParentId = 0;
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUser = 1;
                    menu.IconFont = (string)node.Attributes["iconfont"];               
                    var result = SysMenuService.AddEntity(menu);
                    if (result.IsSuccess)
                    {
                        T_SysMenus addMenu = JsonConvert.DeserializeObject<T_SysMenus>(result.Data);
                        var childNodes = node.ChildNodes;
                        List<T_SysMenus> menuList = new List<T_SysMenus>();
                        foreach (var childNode in childNodes)
                        {
                            T_SysMenus menuNew = new T_SysMenus();
                            menuNew.Guid = Guid.NewGuid().ToString("N");
                            menuNew.MenuName = childNode.Title;
                            menuNew.MenuUrl = "/" + childNode.Controller + "/" + childNode.Action;
                            menuNew.ParentId = addMenu.Id;
                            menuNew.IsLeaf = true;
                            menuNew.CreateTime = DateTime.Now;
                            menuNew.CreateUser = 1;
                            menuList.Add(menuNew);
                        }

                        var resultNew = SysMenuService.AddRange(menuList);
                    }

                }
            }
            return null;
        }

        public ActionResult Init()
        {
            // 1 , 清空冗余数据

            return null;
        }
    }
}