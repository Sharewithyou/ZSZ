using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_SysGroupUsersMap : EntityTypeConfiguration<T_SysGroupUsers>
    {
        public T_SysGroupUsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("T_SysGroupUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.T_AdminUsers)
                .WithMany(t => t.T_SysGroupUsers)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.T_UserGroups)
                .WithMany(t => t.T_SysGroupUsers)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
