using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_user_organismMap : EntityTypeConfiguration<gw_user_organism>
    {
        public gw_user_organismMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_user_organism_user_id);

            // Properties
            this.Property(t => t.gw_user_organism_user_id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.gw_user_organism_organism_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_user_organism");
            this.Property(t => t.gw_user_organism_user_id).HasColumnName("gw_user_organism_user_id");
            this.Property(t => t.gw_user_organism_organism_id).HasColumnName("gw_user_organism_organism_id");
            this.Property(t => t.gw_user_organism_organism_type).HasColumnName("gw_user_organism_organism_type");
        }
    }
}
