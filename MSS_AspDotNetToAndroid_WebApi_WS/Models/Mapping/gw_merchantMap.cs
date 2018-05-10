using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_merchantMap : EntityTypeConfiguration<gw_merchant>
    {
        public gw_merchantMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_merchant_id);

            // Properties
            this.Property(t => t.gw_merchant_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_bank_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_abrev)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_adress)
                .IsRequired();

            this.Property(t => t.gw_merchant_mail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_phone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_convention)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_ftp_adress)
                .HasMaxLength(50);

            this.Property(t => t.gw_merchant_ftp_user_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_merchant");
            this.Property(t => t.gw_merchant_id).HasColumnName("gw_merchant_id");
            this.Property(t => t.gw_merchant_name).HasColumnName("gw_merchant_name");
            this.Property(t => t.gw_merchant_bank_id).HasColumnName("gw_merchant_bank_id");
            this.Property(t => t.gw_merchant_status).HasColumnName("gw_merchant_status");
            this.Property(t => t.gw_merchant_abrev).HasColumnName("gw_merchant_abrev");
            this.Property(t => t.gw_merchant_adress).HasColumnName("gw_merchant_adress");
            this.Property(t => t.gw_merchant_mail).HasColumnName("gw_merchant_mail");
            this.Property(t => t.gw_merchant_phone).HasColumnName("gw_merchant_phone");
            this.Property(t => t.gw_merchant_convention).HasColumnName("gw_merchant_convention");
            this.Property(t => t.gw_merchant_close_day_hour).HasColumnName("gw_merchant_close_day_hour");
            this.Property(t => t.gw_merchant_mobility).HasColumnName("gw_merchant_mobility");
            this.Property(t => t.gw_merchant_ftp_adress).HasColumnName("gw_merchant_ftp_adress");
            this.Property(t => t.gw_merchant_ftp_port).HasColumnName("gw_merchant_ftp_port");
            this.Property(t => t.gw_merchant_ftp_user_id).HasColumnName("gw_merchant_ftp_user_id");
            this.Property(t => t.gw_merchant_ftp_password).HasColumnName("gw_merchant_ftp_password");
            this.Property(t => t.gw_merchant_ftp_repertoire).HasColumnName("gw_merchant_ftp_repertoire");

            // Relationships
            this.HasOptional(t => t.gw_bank)
                .WithMany(t => t.gw_merchant)
                .HasForeignKey(d => d.gw_merchant_bank_id);

        }
    }
}
