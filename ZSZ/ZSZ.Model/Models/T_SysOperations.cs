using System;
using System.Collections.Generic;

namespace ZSZ.Model.Models
{
    public partial class T_SysOperations
    {
        public T_SysOperations()
        {
            this.T_OperatePermissions = new List<T_OperatePermissions>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string TypeName { get; set; }
        public string OperateName { get; set; }
        public string ContronllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsNotShow { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_OperatePermissions> T_OperatePermissions { get; set; }
    }
}
