using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AdminWeb.Autofac
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            //注册控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //注册业务逻辑与数据访问
            Assembly[] assemblies = new Assembly[] { Assembly.Load("ZSZ.Service"), Assembly.Load("ZSZ.DAL") };

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().PropertiesAutowired();
        }
    }
}