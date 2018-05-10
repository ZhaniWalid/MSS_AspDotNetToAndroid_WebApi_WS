using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_subfieldMap : EntityTypeConfiguration<gw_spdh_subfield>
    {
        public gw_spdh_subfieldMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_spdh_subfield_id);

            // Properties
            this.Property(t => t.gw_spdh_subfield_id)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_subfield_label)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.gw_spdh_subfield_sfid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_subfield_format)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_subfield_field_fid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gw_spdh_subfield_padding_char)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("gw_spdh_subfield");
            this.Property(t => t.gw_spdh_subfield_id).HasColumnName("gw_spdh_subfield_id");
            this.Property(t => t.gw_spdh_subfield_label).HasColumnName("gw_spdh_subfield_label");
            this.Property(t => t.gw_spdh_subfield_sfid).HasColumnName("gw_spdh_subfield_sfid");
            this.Property(t => t.gw_spdh_subfield_format).HasColumnName("gw_spdh_subfield_format");
            this.Property(t => t.gw_spdh_subfield_min_length).HasColumnName("gw_spdh_subfield_min_length");
            this.Property(t => t.gw_spdh_subfield_max_length).HasColumnName("gw_spdh_subfield_max_length");
            this.Property(t => t.gw_spdh_subfield_field_fid).HasColumnName("gw_spdh_subfield_field_fid");
            this.Property(t => t.gw_spdh_subfield_padding).HasColumnName("gw_spdh_subfield_padding");
            this.Property(t => t.gw_spdh_subfield_padding_char).HasColumnName("gw_spdh_subfield_padding_char");
            this.Property(t => t.gw_spdh_subfield_extend_control).HasColumnName("gw_spdh_subfield_extend_control");
        }
    }
}
