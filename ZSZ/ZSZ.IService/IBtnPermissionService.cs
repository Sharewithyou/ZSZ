using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.IService
{
    public interface IBtnPermissionService
    {
        /// <summary>
        /// 是否具有按钮权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">方法</param>
        /// <returns></returns>
        bool IsValid(int userId, string controller, string action);
    }
}
