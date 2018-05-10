using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_field_headerMap : EntityTypeConfiguration<gw_spdh_field_header>
    {
        public gw_spdh_field_headerMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_spdh_field_header_id);

            // Properties
            this.Property(t => t.gw_spdh_field_header_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_field_header_format)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_field_header_padding_char)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_field_header_default_value)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_spdh_field_header");
            this.Property(t => t.gw_spdh_field_header_id).HasColumnName("gw_spdh_field_header_id");
            this.Property(t => t.gw_spdh_field_header_position).HasColumnName("gw_spdh_field_header_position");
            this.Property(t => t.gw_spdh_field_header_length).HasColumnName("gw_spdh_field_header_length");
            this.Property(t => t.gw_spdh_field_header_format).HasColumnName("gw_spdh_field_header_format");
            this.Property(t => t.gw_spdh_field_header_padding).HasColumnName("gw_spdh_field_header_padding");
            this.Property(t => t.gw_spdh_field_header_padding_char).HasColumnName("gw_spdh_field_header_padding_char");
            this.Property(t => t.gw_spdh_field_header_extend_control).HasColumnName("gw_spdh_field_header_extend_control");
            this.Property(t => t.gw_spdh_field_header_default_value).HasColumnName("gw_spdh_field_header_default_value");
        }
    }
}
