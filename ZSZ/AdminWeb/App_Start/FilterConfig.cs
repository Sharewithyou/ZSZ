using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.App_Start
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ZszExceptionFilter());

            //这里使用了Autofac容器来实例化Filter对象，然后添加到Global Filter中
            //filters.Add(DependencyResolver.Current.GetService<VisitorAdditionFilter>());
        }
    }
}