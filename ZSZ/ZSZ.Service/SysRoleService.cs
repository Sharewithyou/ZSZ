using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models;

namespace ZSZ.Service
{
    public class SysRoleService : BaseService<T_SysRoles>, ISysRoleService
    {
        public ISysRoleDal SysRoleDal { get; set; }
        public SysRoleService(ISysRoleDal currentDal) : base(currentDal)
        {
            this.SysRoleDal = currentDal;
        }
    }
}
