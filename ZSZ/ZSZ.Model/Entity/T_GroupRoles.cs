using System;
using System.Collections.Generic;

namespace ZSZ.Model
{
    public partial class T_GroupRoles
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int RoleId { get; set; }
        public virtual T_SysRoles T_SysRoles { get; set; }
        public virtual T_UserGroups T_UserGroups { get; set; }
    }
}
