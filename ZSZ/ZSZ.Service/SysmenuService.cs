using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Model;
using AutoMapper;
using Newtonsoft.Json;

namespace ZSZ.Service
{
    public class SysMenuService : BaseService<T_SysMenus>, ISysMenuService
    {
        private ISysMenuDal MenuDal { get; set; }

        public override void SetDal()
        {
            Dal = MenuDal;
        }

        /// <summary>
        /// 获取菜单树节点数据
        /// </summary>
        /// <returns></returns>
        public MsgResult GetMenuTreeNodeData()
        {
            MsgResult result = new MsgResult();
            try
            {
                //var list = MenuDal.GetModels(x => x.IsDeleted == false).Select(x => Mapper.Map<SysMenus>(x)).ToList();
                var list = MenuDal.GetModels(x => x.IsDeleted == false).ToList();
                List<ZtreeNode> nodeList = new List<ZtreeNode>();
                for (int i = 0; i < list.Count; i++)
                {
                    ZtreeNode node = new ZtreeNode();
                    node.Id = list[i].Id;
                    node.Pid = list[i].ParentId;
                    node.Name = list[i].MenuName;
                    nodeList.Add(node);
                }

                result.IsSuccess = true;
                result.Data = JsonConvert.SerializeObject(nodeList);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }




    }
}
