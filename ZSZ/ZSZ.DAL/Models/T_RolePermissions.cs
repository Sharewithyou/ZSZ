using System;
using System.Collections.Generic;

namespace ZSZ.DAL.Models
{
    public partial class T_RolePermissions
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public virtual T_SysPermissions T_SysPermissions { get; set; }
        public virtual T_SysRoles T_SysRoles { get; set; }
    }
}
