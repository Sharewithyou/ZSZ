using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.Model.Entity;
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
        /// 根据菜单Id获取子菜单节点的详细数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MsgResult GetMenuTreeChildNodeListById(int id = 0);

        /// <summary>
        /// 通过ID获取某个菜单节点的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MsgResult GetMenuTreeNodeById(int id = 0);

       
        /// <summary>
        /// 增加菜单节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        MsgResult AddMenuNode(SysMenus node);

        /// <summary>
        /// 跟新菜单节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        MsgResult UpdateMenuNode(SysMenus node);

        /// <summary>
        /// 标记删除菜单节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        MsgResult MarkDeleteNode(SysMenus node);
    }
}
