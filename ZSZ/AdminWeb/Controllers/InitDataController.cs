using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using AdminWeb.App_Start;
using ZSZ.IService;
using ZSZ.Model.Entity;
using ZSZ.Model.Model;

namespace AdminWeb.Controllers
{

    public class InitDataController : Controller
    {

        public ISysRoleService SysRoleService { get; set; }

        public InitDataController(ISysRoleService currntService)
        {
            this.SysRoleService = currntService;
        }

        // GET: InitData
        public ActionResult InitOperationData()
        {
            #region 重置数据

            //清空角色表
            SysRoleService.Clear(typeof(T_SysRoles).Name);

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

                List<SysOperations> list = new List<SysOperations>();

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
                        SysOperations model = new SysOperations();
                        model.ContronllerName = controller.Name.Replace("Controller", "");
                        model.ActionName = action.Name;
                        model.TypeName = typeName;
                        model.Name = attr;
                        list.Add(model);
                    }
                }

                #endregion
            }







            return null;
        }

        public ActionResult Test()
        {
            MsgResult result = SysRoleService.Clear(typeof(T_SysRoles).Name);
            return View();
        }
    }
}