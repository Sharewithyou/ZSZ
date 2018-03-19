using System;
using System.Collections.Generic;

namespace ZSZ.Model
{
    public partial class T_OperatePermissions
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int OperationId { get; set; }
        public virtual T_SysOperations T_SysOperations { get; set; }
        public virtual T_SysPermissions T_SysPermissions { get; set; }
    }
}
