using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_errorMap : EntityTypeConfiguration<gw_spdh_error>
    {
        public gw_spdh_errorMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_spdh_error_code);

            // Properties
            this.Property(t => t.gw_spdh_error_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.gw_spdh_error_description)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("gw_spdh_error");
            this.Property(t => t.gw_spdh_error_code).HasColumnName("gw_spdh_error_code");
            this.Property(t => t.gw_spdh_error_description).HasColumnName("gw_spdh_error_description");
        }
    }
}
