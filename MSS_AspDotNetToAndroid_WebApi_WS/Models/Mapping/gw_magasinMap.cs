using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_magasinMap : EntityTypeConfiguration<gw_magasin>
    {
        public gw_magasinMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_magasin_id);

            // Properties
            this.Property(t => t.gw_magasin_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_magasin_merchant_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_magasin_label)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_magasin_status)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_magasin");
            this.Property(t => t.gw_magasin_id).HasColumnName("gw_magasin_id");
            this.Property(t => t.gw_magasin_merchant_id).HasColumnName("gw_magasin_merchant_id");
            this.Property(t => t.gw_magasin_label).HasColumnName("gw_magasin_label");
            this.Property(t => t.gw_magasin_status).HasColumnName("gw_magasin_status");
            this.Property(t => t.gw_magasin_close_day_hour).HasColumnName("gw_magasin_close_day_hour");
        }
    }
}
