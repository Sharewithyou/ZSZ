using System;
using System.Collections.Generic;

namespace ZSZ.Model
{
    public partial class T_SysOperations
    {
        public T_SysOperations()
        {
            this.T_OperatePermissions = new List<T_OperatePermissions>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int MenuId { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_OperatePermissions> T_OperatePermissions { get; set; }
    }
}
