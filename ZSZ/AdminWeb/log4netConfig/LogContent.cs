using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.log4netConfig
{
    /// <summary>
    /// 自定义日志输出对象
    /// </summary>
    public class LogContent
    {
        public string Reason { get; set; }

       

        public LogContent(string reason)
        {
            this.Reason = reason;
        }
    }
}