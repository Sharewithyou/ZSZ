using System;
using System.Collections.Generic;

namespace ZSZ.Model.Entity
{
    public partial class T_SysLog
    {
        public int Id { get; set; }
        public System.DateTime LogDate { get; set; }
        public string LogLevel { get; set; }
        public string LogLogger { get; set; }
        public string LogMessage { get; set; }
        public int LoginUerId { get; set; }
        public string IpAdress { get; set; }
    }
}
