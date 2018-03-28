using System;
using System.Collections.Generic;

namespace ZSZ.Model.Entity
{
    public partial class T_UserGroups
    {
        public T_UserGroups()
        {
            this.T_GroupRoles = new List<T_GroupRoles>();
            this.T_SysGroupUsers = new List<T_SysGroupUsers>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public string GroupName { get; set; }
        public int ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public virtual ICollection<T_GroupRoles> T_GroupRoles { get; set; }
        public virtual ICollection<T_SysGroupUsers> T_SysGroupUsers { get; set; }
    }
}
