using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_pos_versionMap : EntityTypeConfiguration<gw_pos_version>
    {
        public gw_pos_versionMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_pos_version_id);

            // Properties
            this.Property(t => t.gw_pos_version_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_pos_version_version_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_pos_version_terminal_merchant_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_pos_version_date_debut)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_pos_version_date_fin)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_pos_version");
            this.Property(t => t.gw_pos_version_id).HasColumnName("gw_pos_version_id");
            this.Property(t => t.gw_pos_version_version_id).HasColumnName("gw_pos_version_version_id");
            this.Property(t => t.gw_pos_version_terminal_merchant_id).HasColumnName("gw_pos_version_terminal_merchant_id");
            this.Property(t => t.gw_pos_version_date_debut).HasColumnName("gw_pos_version_date_debut");
            this.Property(t => t.gw_pos_version_date_fin).HasColumnName("gw_pos_version_date_fin");

            // Relationships
            this.HasRequired(t => t.gw_terminal_merchant)
                .WithMany(t => t.gw_pos_version)
                .HasForeignKey(d => d.gw_pos_version_terminal_merchant_id);
            this.HasRequired(t => t.gw_version)
                .WithMany(t => t.gw_pos_version)
                .HasForeignKey(d => d.gw_pos_version_version_id);

        }
    }
}
