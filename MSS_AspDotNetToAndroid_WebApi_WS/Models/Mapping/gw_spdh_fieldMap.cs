using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_fieldMap : EntityTypeConfiguration<gw_spdh_field>
    {
        public gw_spdh_fieldMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_spdh_field_id);

            // Properties
            this.Property(t => t.gw_spdh_field_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_field_fid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_field_format)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_field_label)
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_field_padding_char)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("gw_spdh_field");
            this.Property(t => t.gw_spdh_field_id).HasColumnName("gw_spdh_field_id");
            this.Property(t => t.gw_spdh_field_fid).HasColumnName("gw_spdh_field_fid");
            this.Property(t => t.gw_spdh_field_format).HasColumnName("gw_spdh_field_format");
            this.Property(t => t.gw_spdh_field_min_lengh).HasColumnName("gw_spdh_field_min_lengh");
            this.Property(t => t.gw_spdh_field_max_length).HasColumnName("gw_spdh_field_max_length");
            this.Property(t => t.gw_spdh_field_label).HasColumnName("gw_spdh_field_label");
            this.Property(t => t.gw_spdh_field_request_response).HasColumnName("gw_spdh_field_request_response");
            this.Property(t => t.gw_spdh_field_padding).HasColumnName("gw_spdh_field_padding");
            this.Property(t => t.gw_spdh_field_padding_char).HasColumnName("gw_spdh_field_padding_char");
            this.Property(t => t.gw_spdh_field_extend_control).HasColumnName("gw_spdh_field_extend_control");
        }
    }
}
