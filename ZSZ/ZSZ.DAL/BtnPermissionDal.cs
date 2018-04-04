using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DAL.Models;
using ZSZ.Model.Models;

namespace ZSZ.DAL
{
    public class BtnPermissionDal
    {
        private DbContext dbContext = DbContextFactory.Create();

        /// <summary>
        /// 获取角色的操作权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T_SysOperations> GetSysOperationsByRoleId(int id)
        {
            string sql = "select * from T_SysOperations where Id in( select OperationId from T_OperatePermissions where PermissionId = (select Id from T_SysPermissions where Type = 1 and Id in(select PermissionId from T_RolePermissions where RoleId = @roleID)))";
            return dbContext.Database.SqlQuery<T_SysOperations>(sql, id).ToList();
        }
            
    }
}
