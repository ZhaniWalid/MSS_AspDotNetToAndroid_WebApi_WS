using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_emv_dataMap : EntityTypeConfiguration<gw_emv_data>
    {
        public gw_emv_dataMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_emv_data_tag);

            // Properties
            this.Property(t => t.gw_emv_data_tag)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.gw_emv_data_label)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_emv_data");
            this.Property(t => t.gw_emv_data_tag).HasColumnName("gw_emv_data_tag");
            this.Property(t => t.gw_emv_data_label).HasColumnName("gw_emv_data_label");
        }
    }
}
