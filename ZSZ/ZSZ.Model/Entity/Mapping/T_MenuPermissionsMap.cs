using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Mapping
{
    public class T_MenuPermissionsMap : EntityTypeConfiguration<T_MenuPermissions>
    {
        public T_MenuPermissionsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_MenuPermissions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PermissionId).HasColumnName("PermissionId");
            this.Property(t => t.MenuId).HasColumnName("MenuId");

            // Relationships
            this.HasRequired(t => t.T_SysMenus)
                .WithMany(t => t.T_MenuPermissions)
                .HasForeignKey(d => d.MenuId);
            this.HasRequired(t => t.T_SysPermissions)
                .WithMany(t => t.T_MenuPermissions)
                .HasForeignKey(d => d.PermissionId);

        }
    }
}
