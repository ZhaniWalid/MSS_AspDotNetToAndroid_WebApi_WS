using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_default_subfieldMap : EntityTypeConfiguration<gw_default_subfield>
    {
        public gw_default_subfieldMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_default_subfield_default_template_id, t.gw_default_subfield_subfield_id });

            // Properties
            this.Property(t => t.gw_default_subfield_default_template_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_default_subfield_subfield_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_default_subfield_default_value)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_default_subfield");
            this.Property(t => t.gw_default_subfield_default_template_id).HasColumnName("gw_default_subfield_default_template_id");
            this.Property(t => t.gw_default_subfield_subfield_id).HasColumnName("gw_default_subfield_subfield_id");
            this.Property(t => t.gw_default_subfield_default_value).HasColumnName("gw_default_subfield_default_value");
            this.Property(t => t.gw_default_subfield_extend_creation).HasColumnName("gw_default_subfield_extend_creation");

            // Relationships
            this.HasRequired(t => t.gw_spdh_subfield)
                .WithMany(t => t.gw_default_subfield)
                .HasForeignKey(d => d.gw_default_subfield_subfield_id);
            this.HasRequired(t => t.gw_default_template)
                .WithMany(t => t.gw_default_subfield)
                .HasForeignKey(d => d.gw_default_subfield_default_template_id);

        }
    }
}
