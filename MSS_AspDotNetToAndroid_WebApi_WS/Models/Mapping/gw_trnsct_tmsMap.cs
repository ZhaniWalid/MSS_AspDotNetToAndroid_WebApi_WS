using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_trnsct_tmsMap : EntityTypeConfiguration<gw_trnsct_tms>
    {
        public gw_trnsct_tmsMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_trnsct_tms_id);

            // Properties
            this.Property(t => t.gw_trnsct_tms_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_merchant_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_magasin_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_tpe_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_date)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.gw_trnsct_tms_response)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_tpe_serial_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_binary_version_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tms_config_version_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_trnsct_tms");
            this.Property(t => t.gw_trnsct_tms_id).HasColumnName("gw_trnsct_tms_id");
            this.Property(t => t.gw_trnsct_tms_merchant_id).HasColumnName("gw_trnsct_tms_merchant_id");
            this.Property(t => t.gw_trnsct_tms_magasin_id).HasColumnName("gw_trnsct_tms_magasin_id");
            this.Property(t => t.gw_trnsct_tms_tpe_id).HasColumnName("gw_trnsct_tms_tpe_id");
            this.Property(t => t.gw_trnsct_tms_date).HasColumnName("gw_trnsct_tms_date");
            this.Property(t => t.gw_trnsct_tms_response).HasColumnName("gw_trnsct_tms_response");
            this.Property(t => t.gw_trnsct_tms_tpe_serial_id).HasColumnName("gw_trnsct_tms_tpe_serial_id");
            this.Property(t => t.gw_trnsct_tms_binary_version_id).HasColumnName("gw_trnsct_tms_binary_version_id");
            this.Property(t => t.gw_trnsct_tms_config_version_id).HasColumnName("gw_trnsct_tms_config_version_id");

            // Relationships
            this.HasRequired(t => t.gw_terminal_merchant)
                .WithMany(t => t.gw_trnsct_tms)
                .HasForeignKey(d => d.gw_trnsct_tms_tpe_id);

        }
    }
}
