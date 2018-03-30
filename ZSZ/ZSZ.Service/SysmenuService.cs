using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using ZSZ.Model;
using ZSZ.IDAL;
using ZSZ.IService;
using AutoMapper;
using Newtonsoft.Json;
using log4net;
using ZSZ.Common;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;


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
        /// 根据菜单节点获取子菜单数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsgResult GetMenuTreeChildNodeListById(int id = 0)
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

        /// <summary>
        /// 根据Id获取节点数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsgResult GetMenuTreeNodeById(int id = 0)
        {
            MsgResult result = new MsgResult();
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
                    var node = SysMenuDal.GetModels(x => x.IsDeleted == false & x.Id == id).FirstOrDefault();
                    var parentNode = SysMenuDal.GetModels(x => x.IsDeleted == false & x.Id == node.ParentId).FirstOrDefault();
                    menu = Mapper.Map<SysMenus>(node);
                    menu.ParentName = parentNode.MenuName;
                    result.IsSuccess = true;
                    result.Data = JsonConvert.SerializeObject(menu);
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

        /// <summary>
        /// 增加菜单节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public MsgResult AddMenuNode(SysMenus node)
        {
            MsgResult result = new MsgResult();
            T_SysMenus entity = new T_SysMenus();
            try
            {
                entity = Mapper.Map<T_SysMenus>(node);
                entity.Guid = Guid.NewGuid().ToString("N");
                entity.CreateUser = 1;
                entity.CreateTime = DateTime.Now;
                SysMenuDal.Add(entity);
                SysMenuDal.SaveChanges();
                CacheHelper.RemoveCache("menuList");
                result.IsSuccess = true;
                result.Message = "增加成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "增加失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "增加失败：" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 跟新菜单节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public MsgResult UpdateMenuNode(SysMenus node)
        {
            MsgResult result = new MsgResult();
            T_SysMenus menuEntity = new T_SysMenus();
            try
            {
                menuEntity = Mapper.Map<T_SysMenus>(node);
                SysMenuDal.UpdateEntityFields(menuEntity, new List<string> { "MenuName", "MenuUrl", "SortNum" });
                SysMenuDal.SaveChanges();
                CacheHelper.RemoveCache("menuList");
                result.IsSuccess = true;
                result.Message = "跟新数据成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "跟新失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "跟新失败：" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 标记删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public MsgResult MarkDeleteNode(SysMenus node)
        {
            MsgResult result = new MsgResult();
            T_SysMenus menuEntity = new T_SysMenus();
            try
            {
                menuEntity = Mapper.Map<T_SysMenus>(node);
                menuEntity.IsDeleted = true;             
                SysMenuDal.MarkDelete(menuEntity);
                SysMenuDal.SaveChanges();
                CacheHelper.RemoveCache("menuList");
                result.IsSuccess = true;
                result.Message = "删除数据成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "删除数据失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "删除数据失败：" + ex.Message;
            }
            return result;
        }
    }
}
