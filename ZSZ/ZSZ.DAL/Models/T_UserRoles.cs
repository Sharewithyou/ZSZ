using System;
using System.Collections.Generic;

namespace ZSZ.DAL.Models
{
    public partial class T_UserRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual T_AdminUsers T_AdminUsers { get; set; }
        public virtual T_SysRoles T_SysRoles { get; set; }
    }
}
