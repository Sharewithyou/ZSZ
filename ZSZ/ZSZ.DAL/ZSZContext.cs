using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using log4net;
using ZSZ.Model;
using ZSZ.Model.Models;
using ZSZ.Model.Models.Mapping;

namespace ZSZ.DAL.Models
{
    public partial class ZSZContext : DbContext
    {
        private static ILog log = LogManager.GetLogger(typeof(ZSZContext));
        static ZSZContext()
        {
            Database.SetInitializer<ZSZContext>(null);
        }

        public ZSZContext()
            : base("Name=EfConnStr")
        {
            //this.Database.Log = (sql) => {
            //    log.InfoFormat("EF执行SQL：{0}", sql);
            //};

            //DbInterception.Add(new EFDbCommandInterceptor());

            DbInterception.Add(new NewInterceptor());

            EntityFramework.Utilities.Configuration.Log = (sql) =>
            {
                log.InfoFormat("EntityFramework.Utilities 执行批量操作：{0}", sql);
            };

           
        }

        public DbSet<T_AdminUsers> T_AdminUsers { get; set; }
        public DbSet<T_GroupRoles> T_GroupRoles { get; set; }
        public DbSet<T_MenuPermissions> T_MenuPermissions { get; set; }
        public DbSet<T_OperatePermissions> T_OperatePermissions { get; set; }
        public DbSet<T_RolePermissions> T_RolePermissions { get; set; }
        public DbSet<T_SysGroupUsers> T_SysGroupUsers { get; set; }
        public DbSet<T_SysLog> T_SysLog { get; set; }
        public DbSet<T_SysMenus> T_SysMenus { get; set; }
        public DbSet<T_SysOperations> T_SysOperations { get; set; }
        public DbSet<T_SysPermissions> T_SysPermissions { get; set; }
        public DbSet<T_SysRoles> T_SysRoles { get; set; }
        public DbSet<T_UserGroups> T_UserGroups { get; set; }
        public DbSet<T_UserRoles> T_UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new T_AdminUsersMap());
            modelBuilder.Configurations.Add(new T_GroupRolesMap());
            modelBuilder.Configurations.Add(new T_MenuPermissionsMap());
            modelBuilder.Configurations.Add(new T_OperatePermissionsMap());
            modelBuilder.Configurations.Add(new T_RolePermissionsMap());
            modelBuilder.Configurations.Add(new T_SysGroupUsersMap());
            modelBuilder.Configurations.Add(new T_SysLogMap());
            modelBuilder.Configurations.Add(new T_SysMenusMap());
            modelBuilder.Configurations.Add(new T_SysOperationsMap());
            modelBuilder.Configurations.Add(new T_SysPermissionsMap());
            modelBuilder.Configurations.Add(new T_SysRolesMap());
            modelBuilder.Configurations.Add(new T_UserGroupsMap());
            modelBuilder.Configurations.Add(new T_UserRolesMap());
        }
    }
}
