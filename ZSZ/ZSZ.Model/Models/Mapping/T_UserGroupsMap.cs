using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_UserGroupsMap : EntityTypeConfiguration<T_UserGroups>
    {
        public T_UserGroupsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("T_UserGroups");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.GroupName).HasColumnName("GroupName");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateUser).HasColumnName("CreateUser");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
