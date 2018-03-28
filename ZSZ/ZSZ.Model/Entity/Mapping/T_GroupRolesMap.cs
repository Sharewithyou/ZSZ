using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Entity.Mapping
{
    public class T_GroupRolesMap : EntityTypeConfiguration<T_GroupRoles>
    {
        public T_GroupRolesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_GroupRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");

            // Relationships
            this.HasRequired(t => t.T_SysRoles)
                .WithMany(t => t.T_GroupRoles)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.T_UserGroups)
                .WithMany(t => t.T_GroupRoles)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
