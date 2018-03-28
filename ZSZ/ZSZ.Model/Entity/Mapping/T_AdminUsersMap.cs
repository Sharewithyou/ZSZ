using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Entity.Mapping
{
    public class T_AdminUsersMap : EntityTypeConfiguration<T_AdminUsers>
    {
        public T_AdminUsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Guid)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.Salt)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PwdHush)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("T_AdminUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Guid).HasColumnName("Guid");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Salt).HasColumnName("Salt");
            this.Property(t => t.PwdHush).HasColumnName("PwdHush");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.CreateUser).HasColumnName("CreateUser");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}
