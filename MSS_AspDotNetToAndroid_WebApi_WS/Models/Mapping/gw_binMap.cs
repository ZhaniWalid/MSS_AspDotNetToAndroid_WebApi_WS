using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_binMap : EntityTypeConfiguration<gw_bin>
    {
        public gw_binMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_bin_id);

            // Properties
            this.Property(t => t.gw_bin_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bin_bank_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bin_type)
                .HasMaxLength(50);

            this.Property(t => t.gw_bin_status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_bin_bank_of_request)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_bin");
            this.Property(t => t.gw_bin_id).HasColumnName("gw_bin_id");
            this.Property(t => t.gw_bin_bank_id).HasColumnName("gw_bin_bank_id");
            this.Property(t => t.gw_bin_type).HasColumnName("gw_bin_type");
            this.Property(t => t.gw_bin_label).HasColumnName("gw_bin_label");
            this.Property(t => t.gw_bin_status).HasColumnName("gw_bin_status");
            this.Property(t => t.gw_bin_bank_of_request).HasColumnName("gw_bin_bank_of_request");

            // Relationships
            this.HasRequired(t => t.gw_bank)
                .WithMany(t => t.gw_bin)
                .HasForeignKey(d => d.gw_bin_bank_id);

        }
    }
}
