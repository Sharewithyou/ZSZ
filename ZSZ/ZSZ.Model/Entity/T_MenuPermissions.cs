using System;
using System.Collections.Generic;

namespace ZSZ.Model
{
    public partial class T_MenuPermissions
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int MenuId { get; set; }
        public virtual T_SysMenus T_SysMenus { get; set; }
        public virtual T_SysPermissions T_SysPermissions { get; set; }
    }
}
