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
    }
}
