using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Models;

namespace ZSZ.IDAL
{
    public interface IBtnPermissionDal
    {
        /// <summary>
        /// 获取角色的操作权限
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        List<T_SysOperations> GetSysOperationsByRoleId(int roleId);
    }
}
