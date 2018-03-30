using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminWeb.App_Start
{
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否在授权时展示
        /// </summary>
        public bool IsNotShow { get; set; }
    }
}