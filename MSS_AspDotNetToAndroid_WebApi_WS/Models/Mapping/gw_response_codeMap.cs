using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_response_codeMap : EntityTypeConfiguration<gw_response_code>
    {
        public gw_response_codeMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_response_code_id);

            // Properties
            this.Property(t => t.gw_response_code_id)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("gw_response_code");
            this.Property(t => t.gw_response_code_id).HasColumnName("gw_response_code_id");
            this.Property(t => t.gw_response_code_description).HasColumnName("gw_response_code_description");
        }
    }
}
