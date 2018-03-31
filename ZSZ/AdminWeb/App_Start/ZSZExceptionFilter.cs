using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminWeb.log4netConfig;
using log4net;

namespace AdminWeb.App_Start
{
    public class ZszExceptionFilter : IExceptionFilter
    {
        private static ILog log = LogManager.GetLogger(typeof(ZszExceptionFilter));
        public void OnException(ExceptionContext filterContext)
        {
            log.Fatal(new LogContent("我是test"), filterContext.Exception);
            //log.Fatal(filterContext.Exception);
            //try
            //{
            //    log.Fatal(filterContext.Exception);
            //    //log.Fatal(new LogContent("我是test"));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

        }
    }
}