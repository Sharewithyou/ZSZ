using System;
using System.Collections.Generic;
using System.Linq;
using ZSZ.Model;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Model;
using AutoMapper;
using Newtonsoft.Json;
using log4net;
using ZSZ.Common;

namespace ZSZ.Service
{
    public class SysMenuService : BaseService<T_SysMenus>, ISysMenuService
    {
        private ILog logger = LogManager.GetLogger(typeof(SysMenuService));


        public ISysMenuDal SysMenuDal { get; set; }

        public SysMenuService(ISysMenuDal dal) : base(dal)
        {
            this.SysMenuDal = dal;
        }



        /// <summary>
        /// 获取菜单树节点数据
        /// </summary>
        /// <returns></returns>
        public MsgResult GetMenuTreeNodeData()
        {
            MsgResult result = new MsgResult();
            List<ZtreeNode> nodeList = new List<ZtreeNode>();
            try
            {
                if (CacheHelper.GetCache("menuList") == null)
                {
                    //var list = MenuDal.GetModels(x => x.IsDeleted == false).Select(x => Mapper.Map<SysMenus>(x)).ToList();
                    var list = SysMenuDal.GetModels(x => x.IsDeleted == false).ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        ZtreeNode node = new ZtreeNode();
                        node.Id = list[i].Id;
                        node.Pid = list[i].ParentId;
                        node.Name = list[i].MenuName;
                        nodeList.Add(node);
                    }
                    CacheHelper.SetCache("menuList", nodeList, 3600);
                }
                else
                {
                    nodeList = (List<ZtreeNode>)CacheHelper.GetCache("menuList");
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

        /// <summary>
        /// 根据Id获取节点数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsgResult GetMenuTreeNodeById(int id = 0)
        {
            MsgResult result = new MsgResult();
            List<SysMenus> list = new List<SysMenus>();
            SysMenus menu = new SysMenus();
            try
            {
                if (id <= 0)
                {
                    result.IsSuccess = false;
                    result.Message = "传递参数错误";
                }
                else
                {
                    var parentNode = SysMenuDal.GetModels(x => x.IsDeleted == false & x.Id == id).FirstOrDefault();
                    var model = SysMenuDal.GetModels(x => x.IsDeleted == false && x.ParentId == id).ToList();
                    //注意mapper 需要在查询出结果之后再使用，不能加入EF的表达式树中进行计算
                    list = model.Select(x => Mapper.Map<SysMenus>(x)).ToList();
                    list.ForEach(x => x.ParentName = parentNode.MenuName);
                    result.IsSuccess = true;
                    result.Data = JsonConvert.SerializeObject(list);
                }

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                logger.Error(ex.Message);
            }

            return result;
        }
    }
}
