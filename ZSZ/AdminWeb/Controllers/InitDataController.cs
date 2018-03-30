using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using AdminWeb.App_Start;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace AdminWeb.Controllers
{

    public class InitDataController : Controller
    {

        public ISysRoleService SysRoleService { get; set; }

        public ISysOperationService SysOperationService { get; set; }

        public IAdminUserService AdminUserService { get; set; }


        public InitDataController(ISysRoleService currntService, ISysOperationService sysOperationService, IAdminUserService adminUserService)
        {
            this.SysRoleService = currntService;
            this.SysOperationService = sysOperationService;
            this.AdminUserService = adminUserService;
        }

        // GET: InitData
        public ActionResult InitOperationData()
        {

            #region 重置数据

            //清空用户表
            AdminUserService.Clear(typeof(T_AdminUsers).Name);

            //清空角色表
            SysRoleService.Clear(typeof(T_SysRoles).Name);

            //清空权限表
            SysOperationService.Clear(typeof(T_SysOperations).Name);

            #endregion
            #region 1 , 管理员初始化

            //增加用户
            T_AdminUsers user = new T_AdminUsers();
            user.Phone = "17512039375";
            user.CreateTime = DateTime.Now;
            user.CreateUser = 1;
            user.Salt = "123456";
            user.PwdHush = EncryptHelper.GetMd5("n5187698" + user.Salt);
            user.Guid = Guid.NewGuid().ToString("N");
            MsgResult result1 = AdminUserService.AddEntity(user);

            //增加管理员
            T_SysRoles role = new T_SysRoles();
            role.Guid = Guid.NewGuid().ToString("N");
            role.Name = "超级管理员";
            role.Description = "拥有所有的权限";
            role.CreateUser = 1;
            role.CreateTime = DateTime.Now;
            MsgResult result2 = SysRoleService.AddEntity(role);

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

            MsgResult result3 = SysOperationService.AddRange(list);
            #endregion

            return View();
        }

        public ActionResult Test()
        {
            MsgResult result = SysRoleService.Clear(typeof(T_SysRoles).Name);
            return View();
        }

        public ActionResult Test1()
        {
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
    }
}