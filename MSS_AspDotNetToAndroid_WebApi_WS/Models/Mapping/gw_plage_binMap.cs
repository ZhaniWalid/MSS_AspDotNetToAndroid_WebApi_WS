using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_plage_binMap : EntityTypeConfiguration<gw_plage_bin>
    {
        public gw_plage_binMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_plage_bin_id);

            // Properties
            this.Property(t => t.gw_plage_bin_bank_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_plage_bin_description)
                .HasMaxLength(100);

            this.Property(t => t.gw_plage_bin_status)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_plage_bin");
            this.Property(t => t.gw_plage_bin_id).HasColumnName("gw_plage_bin_id");
            this.Property(t => t.gw_plage_bin_min).HasColumnName("gw_plage_bin_min");
            this.Property(t => t.gw_plage_bin_max).HasColumnName("gw_plage_bin_max");
            this.Property(t => t.gw_plage_bin_bank_id).HasColumnName("gw_plage_bin_bank_id");
            this.Property(t => t.gw_plage_bin_description).HasColumnName("gw_plage_bin_description");
            this.Property(t => t.gw_plage_bin_status).HasColumnName("gw_plage_bin_status");

            // Relationships
            this.HasOptional(t => t.gw_bank)
                .WithMany(t => t.gw_plage_bin)
                .HasForeignKey(d => d.gw_plage_bin_bank_id);

        }
    }
}
