using AdminWeb.Autofac;
using AdminWeb.AutoMapper;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //依赖注入
            AutofacConfig.Register();

            //实体模型映射
            Mapper.Initialize(x => { x.AddProfile<SourceProfile>(); });

            //log4日志          
            //自定义
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Server.MapPath("~") + @"/Log4Net.config"));

        }
    }
}
