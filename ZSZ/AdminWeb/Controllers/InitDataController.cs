using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AdminWeb.App_Start;
using ZSZ.Model.Model;

namespace AdminWeb.Controllers
{
    public class InitDataController : Controller
    {
        // GET: InitData
        public ActionResult InitOperationData()
        {
            List<SysOperations> list = new List<SysOperations>();

            //创建控制器类型列表
            List<Type> controllerTypes = new List<Type>();

            //加载程序集  
            var assembly = Assembly.Load("AdminWeb");

            controllerTypes.AddRange(assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)));

            foreach (var itemType in controllerTypes)
            {
                var controller = assembly.GetTypes().Where(type => type.Name == itemType.Name).FirstOrDefault();
                var actions = controller.GetMethods().Where(method => method.IsDefined(typeof(DescriptionAttribute)));
                foreach (var action in actions)
                {
                    var attr = action.GetCustomAttributes(typeof(DescriptionAttribute));
                    SysOperations model = new SysOperations();
                    model.ContronllerName = controller.Name;
                    model.ActionName = action.Name;

                    list.Add(model);
                }
            }
            return null;
        }
    }
}