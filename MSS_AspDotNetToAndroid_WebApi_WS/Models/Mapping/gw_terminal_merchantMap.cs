using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_terminal_merchantMap : EntityTypeConfiguration<gw_terminal_merchant>
    {
        public gw_terminal_merchantMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_terminal_merchant_id);

            // Properties
            this.Property(t => t.gw_terminal_merchant_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_merchant_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_magasin_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_sequence_number)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.gw_terminal_merchant_batch_number)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.gw_terminal_merchant_imei)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_status)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_date_status)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_binary_version)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_merchant_conf_version)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_terminal_merchant");
            this.Property(t => t.gw_terminal_merchant_id).HasColumnName("gw_terminal_merchant_id");
            this.Property(t => t.gw_terminal_merchant_merchant_id).HasColumnName("gw_terminal_merchant_merchant_id");
            this.Property(t => t.gw_terminal_merchant_magasin_id).HasColumnName("gw_terminal_merchant_magasin_id");
            this.Property(t => t.gw_terminal_merchant_sequence_number).HasColumnName("gw_terminal_merchant_sequence_number");
            this.Property(t => t.gw_terminal_merchant_batch_number).HasColumnName("gw_terminal_merchant_batch_number");
            this.Property(t => t.gw_terminal_merchant_imei).HasColumnName("gw_terminal_merchant_imei");
            this.Property(t => t.gw_terminal_merchant_status).HasColumnName("gw_terminal_merchant_status");
            this.Property(t => t.gw_terminal_merchant_status_occupancy).HasColumnName("gw_terminal_merchant_status_occupancy");
            this.Property(t => t.gw_terminal_merchant_date_status).HasColumnName("gw_terminal_merchant_date_status");
            this.Property(t => t.gw_terminal_merchant_binary_version).HasColumnName("gw_terminal_merchant_binary_version");
            this.Property(t => t.gw_terminal_merchant_conf_version).HasColumnName("gw_terminal_merchant_conf_version");

            // Relationships
            this.HasOptional(t => t.gw_magasin)
                .WithMany(t => t.gw_terminal_merchant)
                .HasForeignKey(d => d.gw_terminal_merchant_magasin_id);
            this.HasOptional(t => t.gw_merchant)
                .WithMany(t => t.gw_terminal_merchant)
                .HasForeignKey(d => d.gw_terminal_merchant_merchant_id);

        }
    }
}
