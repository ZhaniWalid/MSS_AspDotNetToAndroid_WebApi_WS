using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_hostMap : EntityTypeConfiguration<gw_host>
    {
        public gw_hostMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_host_id);

            // Properties
            this.Property(t => t.gw_host_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_host_label)
                .HasMaxLength(100);

            this.Property(t => t.gw_host_status)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_host_protocol)
                .HasMaxLength(50);

            this.Property(t => t.gw_host_adress)
                .HasMaxLength(50);

            this.Property(t => t.gw_host_port)
                .HasMaxLength(50);

            this.Property(t => t.gw_host_second_adress)
                .HasMaxLength(50);

            this.Property(t => t.gw_host_second_port)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_host");
            this.Property(t => t.gw_host_id).HasColumnName("gw_host_id");
            this.Property(t => t.gw_host_label).HasColumnName("gw_host_label");
            this.Property(t => t.gw_host_status).HasColumnName("gw_host_status");
            this.Property(t => t.gw_host_protocol).HasColumnName("gw_host_protocol");
            this.Property(t => t.gw_host_adress).HasColumnName("gw_host_adress");
            this.Property(t => t.gw_host_port).HasColumnName("gw_host_port");
            this.Property(t => t.gw_host_ssl).HasColumnName("gw_host_ssl");
            this.Property(t => t.gw_host_second_adress).HasColumnName("gw_host_second_adress");
            this.Property(t => t.gw_host_second_port).HasColumnName("gw_host_second_port");
            this.Property(t => t.gw_host_certificate).HasColumnName("gw_host_certificate");
            this.Property(t => t.gw_host_second_certificate).HasColumnName("gw_host_second_certificate");
            this.Property(t => t.gw_host_time_out_behavoir).HasColumnName("gw_host_time_out_behavoir");
        }
    }
}
