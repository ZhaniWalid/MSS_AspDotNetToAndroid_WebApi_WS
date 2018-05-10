using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_subfield_dataMap : EntityTypeConfiguration<gw_spdh_subfield_data>
    {
        public gw_spdh_subfield_dataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_spdh_subfield_data_emv_tag, t.gw_spdh_subfield_data_subfield_id });

            // Properties
            this.Property(t => t.gw_spdh_subfield_data_emv_tag)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_spdh_subfield_data_subfield_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_subfield_data_emv_version)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_spdh_subfield_data_format)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("gw_spdh_subfield_data");
            this.Property(t => t.gw_spdh_subfield_data_emv_tag).HasColumnName("gw_spdh_subfield_data_emv_tag");
            this.Property(t => t.gw_spdh_subfield_data_subfield_id).HasColumnName("gw_spdh_subfield_data_subfield_id");
            this.Property(t => t.gw_spdh_subfield_data_emv_version).HasColumnName("gw_spdh_subfield_data_emv_version");
            this.Property(t => t.gw_spdh_subfield_data_position).HasColumnName("gw_spdh_subfield_data_position");
            this.Property(t => t.gw_spdh_subfield_data_min_length).HasColumnName("gw_spdh_subfield_data_min_length");
            this.Property(t => t.gw_spdh_subfield_data_max_length).HasColumnName("gw_spdh_subfield_data_max_length");
            this.Property(t => t.gw_spdh_subfield_data_format).HasColumnName("gw_spdh_subfield_data_format");
            this.Property(t => t.gw_spdh_subfield_data_request_response).HasColumnName("gw_spdh_subfield_data_request_response");
            this.Property(t => t.gw_spdh_subfield_data_extend_control).HasColumnName("gw_spdh_subfield_data_extend_control");

            // Relationships
            this.HasRequired(t => t.gw_spdh_subfield)
                .WithMany(t => t.gw_spdh_subfield_data)
                .HasForeignKey(d => d.gw_spdh_subfield_data_subfield_id);

        }
    }
}
