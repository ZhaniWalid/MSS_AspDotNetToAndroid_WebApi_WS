using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_tpeMap : EntityTypeConfiguration<gw_tpe>
    {
        public gw_tpeMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_tpe_serial_code);

            // Properties
            this.Property(t => t.gw_tpe_serial_code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_tpe_merchant_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_tpe_magasin_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_tpe");
            this.Property(t => t.gw_tpe_serial_code).HasColumnName("gw_tpe_serial_code");
            this.Property(t => t.gw_tpe_merchant_id).HasColumnName("gw_tpe_merchant_id");
            this.Property(t => t.gw_tpe_magasin_id).HasColumnName("gw_tpe_magasin_id");
            this.Property(t => t.gw_tpe_availability).HasColumnName("gw_tpe_availability");

            // Relationships
            this.HasOptional(t => t.gw_magasin)
                .WithMany(t => t.gw_tpe)
                .HasForeignKey(d => d.gw_tpe_magasin_id);
            this.HasOptional(t => t.gw_merchant)
                .WithMany(t => t.gw_tpe)
                .HasForeignKey(d => d.gw_tpe_merchant_id);

        }
    }
}
