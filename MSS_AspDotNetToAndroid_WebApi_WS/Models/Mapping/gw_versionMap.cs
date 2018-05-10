using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_versionMap : EntityTypeConfiguration<gw_version>
    {
        public gw_versionMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_version_id);

            // Properties
            this.Property(t => t.gw_version_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_version_zip_file)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_version_description)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_version_date_creation)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_version");
            this.Property(t => t.gw_version_id).HasColumnName("gw_version_id");
            this.Property(t => t.gw_version_zip_file).HasColumnName("gw_version_zip_file");
            this.Property(t => t.gw_version_type).HasColumnName("gw_version_type");
            this.Property(t => t.gw_version_description).HasColumnName("gw_version_description");
            this.Property(t => t.gw_version_date_creation).HasColumnName("gw_version_date_creation");
            this.Property(t => t.gw_versin_status).HasColumnName("gw_versin_status");
        }
    }
}
