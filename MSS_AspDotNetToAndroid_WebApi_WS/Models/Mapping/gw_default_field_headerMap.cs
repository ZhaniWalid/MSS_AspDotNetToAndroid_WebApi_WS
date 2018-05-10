using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_default_field_headerMap : EntityTypeConfiguration<gw_default_field_header>
    {
        public gw_default_field_headerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_default_field_header_default_template_id, t.gw_default_field_header_header_id });

            // Properties
            this.Property(t => t.gw_default_field_header_default_template_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_default_field_header_header_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_default_field_header_default_value)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_default_field_header");
            this.Property(t => t.gw_default_field_header_default_template_id).HasColumnName("gw_default_field_header_default_template_id");
            this.Property(t => t.gw_default_field_header_header_id).HasColumnName("gw_default_field_header_header_id");
            this.Property(t => t.gw_default_field_header_default_value).HasColumnName("gw_default_field_header_default_value");
            this.Property(t => t.gw_default_field_header_extend_creation).HasColumnName("gw_default_field_header_extend_creation");

            // Relationships
            this.HasRequired(t => t.gw_spdh_field_header)
                .WithMany(t => t.gw_default_field_header)
                .HasForeignKey(d => d.gw_default_field_header_header_id);
            this.HasRequired(t => t.gw_default_template)
                .WithMany(t => t.gw_default_field_header)
                .HasForeignKey(d => d.gw_default_field_header_default_template_id);

        }
    }
}
