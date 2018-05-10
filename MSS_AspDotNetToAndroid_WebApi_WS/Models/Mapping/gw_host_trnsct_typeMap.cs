using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_host_trnsct_typeMap : EntityTypeConfiguration<gw_host_trnsct_type>
    {
        public gw_host_trnsct_typeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_host_trnsct_type_host_id, t.gw_host_trnsct_type_trnsct_type });

            // Properties
            this.Property(t => t.gw_host_trnsct_type_host_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_host_trnsct_type_trnsct_type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_host_trnsct_type_template_id)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_host_trnsct_type");
            this.Property(t => t.gw_host_trnsct_type_host_id).HasColumnName("gw_host_trnsct_type_host_id");
            this.Property(t => t.gw_host_trnsct_type_trnsct_type).HasColumnName("gw_host_trnsct_type_trnsct_type");
            this.Property(t => t.gw_host_trnsct_type_template_id).HasColumnName("gw_host_trnsct_type_template_id");

            // Relationships
            this.HasRequired(t => t.gw_host)
                .WithMany(t => t.gw_host_trnsct_type)
                .HasForeignKey(d => d.gw_host_trnsct_type_host_id);
            this.HasRequired(t => t.gw_template)
                .WithMany(t => t.gw_host_trnsct_type)
                .HasForeignKey(d => d.gw_host_trnsct_type_template_id);

        }
    }
}
