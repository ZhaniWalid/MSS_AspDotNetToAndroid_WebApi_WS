using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_default_trnsct_typeMap : EntityTypeConfiguration<gw_default_trnsct_type>
    {
        public gw_default_trnsct_typeMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_default_trnsct_type_trnsct_type);

            // Properties
            this.Property(t => t.gw_default_trnsct_type_trnsct_type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_default_trnsct_type_default_template_id)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_default_trnsct_type");
            this.Property(t => t.gw_default_trnsct_type_trnsct_type).HasColumnName("gw_default_trnsct_type_trnsct_type");
            this.Property(t => t.gw_default_trnsct_type_default_template_id).HasColumnName("gw_default_trnsct_type_default_template_id");

            // Relationships
            this.HasRequired(t => t.gw_default_template)
                .WithMany(t => t.gw_default_trnsct_type)
                .HasForeignKey(d => d.gw_default_trnsct_type_default_template_id);

        }
    }
}
