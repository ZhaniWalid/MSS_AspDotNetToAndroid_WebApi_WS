using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_bankMap : EntityTypeConfiguration<gw_bank>
    {
        public gw_bankMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_bank_id);

            // Properties
            this.Property(t => t.gw_bank_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bank_host_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bank_name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_bank_status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bank_abrev)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bank_adress)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.gw_bank_mail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bank_phone)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_bank");
            this.Property(t => t.gw_bank_id).HasColumnName("gw_bank_id");
            this.Property(t => t.gw_bank_host_id).HasColumnName("gw_bank_host_id");
            this.Property(t => t.gw_bank_name).HasColumnName("gw_bank_name");
            this.Property(t => t.gw_bank_status).HasColumnName("gw_bank_status");
            this.Property(t => t.gw_bank_abrev).HasColumnName("gw_bank_abrev");
            this.Property(t => t.gw_bank_adress).HasColumnName("gw_bank_adress");
            this.Property(t => t.gw_bank_mail).HasColumnName("gw_bank_mail");
            this.Property(t => t.gw_bank_phone).HasColumnName("gw_bank_phone");

            // Relationships
            this.HasRequired(t => t.gw_host)
                .WithMany(t => t.gw_bank)
                .HasForeignKey(d => d.gw_bank_host_id);

        }
    }
}
