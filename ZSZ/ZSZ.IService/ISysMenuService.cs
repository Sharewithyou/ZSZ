using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.Model.Model;

namespace ZSZ.IService
{
    public interface ISysMenuService : IBaseService<T_SysMenus>
    {
        /// <summary>
        /// 获取菜单节点数据
        /// </summary>
        /// <returns></returns>
        MsgResult GetMenuTreeNodeData();

        /// <summary>
        /// 根据菜单Id获取菜单的详细数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MsgResult GetMenuTreeNodeById(int id = 0);
    }
}
