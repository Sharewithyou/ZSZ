using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_UserRolesMap : EntityTypeConfiguration<T_UserRoles>
    {
        public T_UserRolesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_UserRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");

            // Relationships
            this.HasRequired(t => t.T_AdminUsers)
                .WithMany(t => t.T_UserRoles)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.T_SysRoles)
                .WithMany(t => t.T_UserRoles)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
