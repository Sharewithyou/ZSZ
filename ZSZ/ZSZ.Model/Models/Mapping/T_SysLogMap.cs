using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZSZ.Model.Models.Mapping
{
    public class T_SysLogMap : EntityTypeConfiguration<T_SysLog>
    {
        public T_SysLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LogLevel)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LogLogger)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.LogMessage)
                .IsRequired();

            this.Property(t => t.IpAdress)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("T_SysLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LogDate).HasColumnName("LogDate");
            this.Property(t => t.LogLevel).HasColumnName("LogLevel");
            this.Property(t => t.LogLogger).HasColumnName("LogLogger");
            this.Property(t => t.LogMessage).HasColumnName("LogMessage");
            this.Property(t => t.LoginUerId).HasColumnName("LoginUerId");
            this.Property(t => t.IpAdress).HasColumnName("IpAdress");
        }
    }
}
