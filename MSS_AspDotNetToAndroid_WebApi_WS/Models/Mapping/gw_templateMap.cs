using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_templateMap : EntityTypeConfiguration<gw_template>
    {
        public gw_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_template_id);

            // Properties
            this.Property(t => t.gw_template_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_template_description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_template");
            this.Property(t => t.gw_template_id).HasColumnName("gw_template_id");
            this.Property(t => t.gw_template_description).HasColumnName("gw_template_description");
        }
    }
}
