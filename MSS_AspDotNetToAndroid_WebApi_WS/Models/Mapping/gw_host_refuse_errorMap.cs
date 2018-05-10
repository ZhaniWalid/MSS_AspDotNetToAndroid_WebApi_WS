using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_host_refuse_errorMap : EntityTypeConfiguration<gw_host_refuse_error>
    {
        public gw_host_refuse_errorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gw_host_refuse_error_host_id, t.gw_host_refuse_error_field_name, t.gw_host_refuse_error_code_error, t.gw_host_refuse_error_request_response });

            // Properties
            this.Property(t => t.gw_host_refuse_error_host_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_host_refuse_error_field_name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.gw_host_refuse_error_code_error)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.gw_host_refuse_error_request_response)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("gw_host_refuse_error");
            this.Property(t => t.gw_host_refuse_error_host_id).HasColumnName("gw_host_refuse_error_host_id");
            this.Property(t => t.gw_host_refuse_error_field_name).HasColumnName("gw_host_refuse_error_field_name");
            this.Property(t => t.gw_host_refuse_error_code_error).HasColumnName("gw_host_refuse_error_code_error");
            this.Property(t => t.gw_host_refuse_error_request_response).HasColumnName("gw_host_refuse_error_request_response");

            // Relationships
            this.HasRequired(t => t.gw_host)
                .WithMany(t => t.gw_host_refuse_error)
                .HasForeignKey(d => d.gw_host_refuse_error_host_id);
            this.HasRequired(t => t.gw_spdh_error)
                .WithMany(t => t.gw_host_refuse_error)
                .HasForeignKey(d => d.gw_host_refuse_error_code_error);

        }
    }
}
