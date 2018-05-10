using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_mandatory_subfieldMap : EntityTypeConfiguration<gw_mandatory_subfield>
    {
        public gw_mandatory_subfieldMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_mandatory_subfield_template_id, t.gw_mandatory_subfield_subfield_id });

            // Properties
            this.Property(t => t.gw_mandatory_subfield_template_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_mandatory_subfield_subfield_id)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_mandatory_subfield");
            this.Property(t => t.gw_mandatory_subfield_template_id).HasColumnName("gw_mandatory_subfield_template_id");
            this.Property(t => t.gw_mandatory_subfield_subfield_id).HasColumnName("gw_mandatory_subfield_subfield_id");
            this.Property(t => t.gw_mandatory_subfield_is_mandatory).HasColumnName("gw_mandatory_subfield_is_mandatory");

            // Relationships
            this.HasRequired(t => t.gw_spdh_subfield)
                .WithMany(t => t.gw_mandatory_subfield)
                .HasForeignKey(d => d.gw_mandatory_subfield_subfield_id);
            this.HasRequired(t => t.gw_template)
                .WithMany(t => t.gw_mandatory_subfield)
                .HasForeignKey(d => d.gw_mandatory_subfield_template_id);

        }
    }
}
