using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.DAL.Models.Mapping
{
    public class T_SysRolesMap : EntityTypeConfiguration<T_SysRoles>
    {
        public T_SysRolesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("T_SysRoles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateUser).HasColumnName("CreateUser");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
