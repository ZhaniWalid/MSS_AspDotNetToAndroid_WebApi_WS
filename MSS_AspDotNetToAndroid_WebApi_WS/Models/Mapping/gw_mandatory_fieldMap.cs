using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_mandatory_fieldMap : EntityTypeConfiguration<gw_mandatory_field>
    {
        public gw_mandatory_fieldMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_mandatory_field_template_id, t.gw_mandatory_field_field_id });

            // Properties
            this.Property(t => t.gw_mandatory_field_template_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_mandatory_field_field_id)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_mandatory_field");
            this.Property(t => t.gw_mandatory_field_template_id).HasColumnName("gw_mandatory_field_template_id");
            this.Property(t => t.gw_mandatory_field_field_id).HasColumnName("gw_mandatory_field_field_id");
            this.Property(t => t.gw_mandatory_field_is_mandatory).HasColumnName("gw_mandatory_field_is_mandatory");

            // Relationships
            this.HasRequired(t => t.gw_spdh_field)
                .WithMany(t => t.gw_mandatory_field)
                .HasForeignKey(d => d.gw_mandatory_field_field_id);
            this.HasRequired(t => t.gw_template)
                .WithMany(t => t.gw_mandatory_field)
                .HasForeignKey(d => d.gw_mandatory_field_template_id);

        }
    }
}
