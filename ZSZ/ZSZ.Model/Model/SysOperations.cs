using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Model
{
    public class SysOperations
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string ContronllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
