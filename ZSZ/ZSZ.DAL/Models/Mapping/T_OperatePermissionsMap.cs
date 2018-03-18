using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.DAL.Models.Mapping
{
    public class T_OperatePermissionsMap : EntityTypeConfiguration<T_OperatePermissions>
    {
        public T_OperatePermissionsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_OperatePermissions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PermissionId).HasColumnName("PermissionId");
            this.Property(t => t.OperationId).HasColumnName("OperationId");

            // Relationships
            this.HasRequired(t => t.T_SysOperations)
                .WithMany(t => t.T_OperatePermissions)
                .HasForeignKey(d => d.OperationId);
            this.HasRequired(t => t.T_SysPermissions)
                .WithMany(t => t.T_OperatePermissions)
                .HasForeignKey(d => d.PermissionId);

        }
    }
}
