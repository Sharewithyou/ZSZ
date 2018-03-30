using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_SysMenusMap : EntityTypeConfiguration<T_SysMenus>
    {
        public T_SysMenusMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Guid)
                .HasMaxLength(32);

            this.Property(t => t.MenuName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MenuUrl)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("T_SysMenus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.MenuName).HasColumnName("MenuName");
            this.Property(t => t.MenuUrl).HasColumnName("MenuUrl");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.SortNum).HasColumnName("SortNum");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateUser).HasColumnName("CreateUser");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
