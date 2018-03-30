using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_RolePermissionsMap : EntityTypeConfiguration<T_RolePermissions>
    {
        public T_RolePermissionsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_RolePermissions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.PermissionId).HasColumnName("PermissionId");

            // Relationships
            this.HasRequired(t => t.T_SysPermissions)
                .WithMany(t => t.T_RolePermissions)
                .HasForeignKey(d => d.PermissionId);
            this.HasRequired(t => t.T_SysRoles)
                .WithMany(t => t.T_RolePermissions)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
