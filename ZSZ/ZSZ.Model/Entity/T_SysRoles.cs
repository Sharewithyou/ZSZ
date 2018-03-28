using System;
using System.Collections.Generic;

namespace ZSZ.Model.Entity
{
    public partial class T_SysRoles
    {
        public T_SysRoles()
        {
            this.T_GroupRoles = new List<T_GroupRoles>();
            this.T_RolePermissions = new List<T_RolePermissions>();
            this.T_UserRoles = new List<T_UserRoles>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_GroupRoles> T_GroupRoles { get; set; }
        public virtual ICollection<T_RolePermissions> T_RolePermissions { get; set; }
        public virtual ICollection<T_UserRoles> T_UserRoles { get; set; }
    }
}
