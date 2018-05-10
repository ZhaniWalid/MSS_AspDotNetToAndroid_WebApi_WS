using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_matchMap : EntityTypeConfiguration<gw_match>
    {
        public gw_matchMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_match_fieldname);

            // Properties
            this.Property(t => t.gw_match_fieldname)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_match");
            this.Property(t => t.gw_match_fieldname).HasColumnName("gw_match_fieldname");
            this.Property(t => t.gw_match_description).HasColumnName("gw_match_description");
        }
    }
}
