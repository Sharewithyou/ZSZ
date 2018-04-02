using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace ZSZ.Service
{
    public class InitDataService : IInitDataService
    {
        public IAdminUserDal AdminUserDal { get; set; }
        public ISysRoleDal SysRoleDal { get; set; }
        public ISysPermissionDal SysPermissionDal { get; set; }
        public ISysOperationDal SysOperationDal { get; set; }
        public InitDataService(IAdminUserDal adminUserDal, ISysRoleDal sysRoleDal, ISysOperationDal sysOperationDal, ISysPermissionDal sysPermissionDal)
        {
            this.AdminUserDal = adminUserDal;
            this.SysRoleDal = sysRoleDal;
            this.SysOperationDal = SysOperationDal;
            this.SysPermissionDal = sysPermissionDal;
        }
        public MsgResult InitData(List<T_SysOperations> list)
        {
            MsgResult result = new MsgResult();
         
                //1 , 清除数据

                //AdminUserDal.Clear(typeof(T_UserRoles).Name);
                //AdminUserDal.Clear(typeof(T_RolePermissions).Name);
                //AdminUserDal.Clear(typeof(T_OperatePermissions).Name);

                //AdminUserDal.Clear(typeof(T_AdminUsers).Name);
                //SysRoleDal.Clear(typeof(T_SysRoles).Name);
                //AdminUserDal.Clear(typeof(T_SysPermissions).Name);
                //SysOperationDal.Clear(typeof(T_SysOperations).Name);

                //2 , 初始化数据

                //用户
                T_AdminUsers adminUser = new T_AdminUsers();
                adminUser.Phone = "17512039375";
                adminUser.CreateTime = DateTime.Now;
                adminUser.CreateUser = 1;
                adminUser.Salt = "123456";
                adminUser.PwdHush = EncryptHelper.GetMd5("n5187698" + adminUser.Salt);
                adminUser.Guid = Guid.NewGuid().ToString("N");
                var addUser = AdminUserDal.Add(adminUser);
                AdminUserDal.SaveChanges();


                //角色
                T_SysRoles role = new T_SysRoles();
                role.Guid = Guid.NewGuid().ToString("N");
                role.Name = "超级管理员";
                role.Description = "拥有所有的权限";
                role.CreateUser = adminUser.Id;
                role.CreateTime = DateTime.Now;

                //权限
                T_SysPermissions permission = new T_SysPermissions();
                permission.Guid = Guid.NewGuid().ToString("N");
                permission.Type = 1;
                permission.Description = "操作权限";
                permission.CreateUser = adminUser.Id;
                permission.CreateTime = DateTime.Now;

                //增加数据
                //var addUser = AdminUserDal.Add(adminUser);
                var addRole = SysRoleDal.Add(role);
                var addPermission = SysPermissionDal.Add(permission);
                var addPerList = SysOperationDal.AddRange(list);
                AdminUserDal.SaveChanges();

                //增加关系
                T_UserRoles userRole = new T_UserRoles();
                userRole.UserId = addUser.Id;
                userRole.RoleId = addRole.Id;


                //用户角色
                adminUser.T_UserRoles.Add(userRole);
                AdminUserDal.SaveChanges();


                T_RolePermissions permissions = new T_RolePermissions();
                permissions.RoleId = addRole.Id;
                permissions.PermissionId = addPermission.Id;

                //角色权限
                role.T_RolePermissions.Add(permissions);


                List<T_OperatePermissions> addOperatelist = new List<T_OperatePermissions>();
                for (int i = 0; i < list.Count; i++)
                {
                    T_OperatePermissions operate = new T_OperatePermissions();
                    operate.PermissionId = addPermission.Id;
                    operate.OperationId = list[i].Id;
                    addOperatelist.Add(operate);
                }

                //权限操作
                permission.T_OperatePermissions = addOperatelist;

                AdminUserDal.SaveChanges();

                //adminUser.T_UserRoles.Add(role);
                //SysOperationDal.AddRange(list);

                //adminUser.T_UserRoles.Add(role);
          

            return null;
        }
    }
}
