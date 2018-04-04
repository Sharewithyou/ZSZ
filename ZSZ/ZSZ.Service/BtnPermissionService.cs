using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.log4;

namespace ZSZ.Service
{
    public class BtnPermissionService : IBtnPermissionService
    {
        public IAdminUserDal AdminUserDal { get; set; }
        public ISysPermissionDal SysPermissionDal { get; set; }
        public IBtnPermissionDal BtnPermissionDal { get; set; }

        //public BtnPermissionService(IAdminUserDal adminUserDal, ISysPermissionDal sysPermissionDal, IBtnPermissionDal btnPermissionDal)
        //{
        //    this.AdminUserDal = adminUserDal;
        //    this.SysPermissionDal = sysPermissionDal;
        //    this.BtnPermissionDal = btnPermissionDal;
        //}

        private static ILog log = LogManager.GetLogger(typeof(BtnPermissionService));

        /// <summary>
        /// 查看用户是否有某个权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">方法</param>
        /// <returns></returns>
        public bool IsValid(int userId, string controller, string action)
        {
            try
            {
                var model = AdminUserDal.GetModels(x => x.Id == userId).FirstOrDefault();
                if (model != null)
                {
                    var cache = CacheHelper.GetCache("SysOp" + model.Id);
                    List<T_SysOperations> list = new List<T_SysOperations>();
                    if (cache == null)
                    {
                        foreach (var role in model.T_UserRoles)
                        {
                            var tempList = BtnPermissionDal.GetSysOperationsByRoleId(role.Id);
                            list.AddRange(tempList);
                        }
                        CacheHelper.SetCache("SysOp" + model.Id, list);
                    }
                    else
                    {
                        list = (List<T_SysOperations>)cache;
                    }

                    if (list.Any(x => x.ContronllerName == controller & x.ActionName == action))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Fatal(new LogContent("查询用户角色权限失败：", ex.Message));
                return false;
            }

        }
    }
}
