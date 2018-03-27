using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IService;
using ZSZ.Model;
using ZSZ.Model.Model;

namespace ZSZ.IService
{
    public interface IAdminUserService 
    {
        /// <summary>
        /// 增加后台用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        MsgResult AddAdminUser(AdminUser user);
    }
}
