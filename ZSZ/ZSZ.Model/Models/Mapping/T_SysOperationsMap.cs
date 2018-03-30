using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_SysOperationsMap : EntityTypeConfiguration<T_SysOperations>
    {
        public T_SysOperationsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.TypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.OperateName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ContronllerName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ActionName)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("T_SysOperations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
            this.Property(t => t.OperateName).HasColumnName("OperateName");
            this.Property(t => t.ContronllerName).HasColumnName("ContronllerName");
            this.Property(t => t.ActionName).HasColumnName("ActionName");
            this.Property(t => t.IsNotShow).HasColumnName("IsNotShow");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateUser).HasColumnName("CreateUser");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
