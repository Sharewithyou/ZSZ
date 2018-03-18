using System;
using System.Collections.Generic;

namespace ZSZ.DAL.Models
{
    public partial class T_SysPermissions
    {
        public T_SysPermissions()
        {
            this.T_MenuPermissions = new List<T_MenuPermissions>();
            this.T_OperatePermissions = new List<T_OperatePermissions>();
            this.T_RolePermissions = new List<T_RolePermissions>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_MenuPermissions> T_MenuPermissions { get; set; }
        public virtual ICollection<T_OperatePermissions> T_OperatePermissions { get; set; }
        public virtual ICollection<T_RolePermissions> T_RolePermissions { get; set; }
    }
}
