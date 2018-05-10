using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_status_codeMap : EntityTypeConfiguration<gw_status_code>
    {
        public gw_status_codeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_status_code_id, t.gw_status_code_type_trnsct });

            // Properties
            this.Property(t => t.gw_status_code_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_status_code_type_trnsct)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_status_code");
            this.Property(t => t.gw_status_code_id).HasColumnName("gw_status_code_id");
            this.Property(t => t.gw_status_code_type_trnsct).HasColumnName("gw_status_code_type_trnsct");
            this.Property(t => t.gw_status_code_description).HasColumnName("gw_status_code_description");
        }
    }
}
