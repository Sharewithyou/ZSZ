using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace ZSZ.IService
{
    public interface IInitDataService
    {
        /// <summary>
        /// 初始化所有数据
        /// </summary>
        MsgResult InitData(List<T_SysOperations> list);

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="list">菜单集合</param>
        /// <returns></returns>
        MsgResult InitMenu(List<T_SysMenus> list);
    }
}
