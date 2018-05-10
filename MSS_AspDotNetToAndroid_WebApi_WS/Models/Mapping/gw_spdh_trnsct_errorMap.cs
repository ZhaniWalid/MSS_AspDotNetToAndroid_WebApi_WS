using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_spdh_trnsct_errorMap : EntityTypeConfiguration<gw_spdh_trnsct_error>
    {
        public gw_spdh_trnsct_errorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_spdh_trnsct_error_trnsct_id, t.gw_spdh_trnsct_error_field_name, t.gw_spdh_trnsct_error_error_code, t.gw_spdh_trnsct_error_request_response });

            // Properties
            this.Property(t => t.gw_spdh_trnsct_error_trnsct_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_spdh_trnsct_error_field_name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.gw_spdh_trnsct_error_error_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.gw_spdh_trnsct_error_request_response)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("gw_spdh_trnsct_error");
            this.Property(t => t.gw_spdh_trnsct_error_trnsct_id).HasColumnName("gw_spdh_trnsct_error_trnsct_id");
            this.Property(t => t.gw_spdh_trnsct_error_field_name).HasColumnName("gw_spdh_trnsct_error_field_name");
            this.Property(t => t.gw_spdh_trnsct_error_error_code).HasColumnName("gw_spdh_trnsct_error_error_code");
            this.Property(t => t.gw_spdh_trnsct_error_request_response).HasColumnName("gw_spdh_trnsct_error_request_response");

            // Relationships
            this.HasRequired(t => t.gw_spdh_error)
                .WithMany(t => t.gw_spdh_trnsct_error)
                .HasForeignKey(d => d.gw_spdh_trnsct_error_error_code);

        }
    }
}
