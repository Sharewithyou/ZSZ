using System;
using System.Collections.Generic;

namespace ZSZ.Model.Entity
{
    public partial class T_SysGroupUsers
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public virtual T_AdminUsers T_AdminUsers { get; set; }
        public virtual T_UserGroups T_UserGroups { get; set; }
    }
}
