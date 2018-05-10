using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_trnsct_tmkMap : EntityTypeConfiguration<gw_trnsct_tmk>
    {
        public gw_trnsct_tmkMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_trnsct_tmk_id);

            // Properties
            this.Property(t => t.gw_trnsct_tmk_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_id_merchant)
                .HasMaxLength(50);

            this.Property(t => t.gw_id_magasin)
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tmk_id_terminal)
                .HasMaxLength(20);

            this.Property(t => t.gw_trnsct_tmk_serial_number)
                .HasMaxLength(20);

            this.Property(t => t.gw_trnsct_tmk_current_date)
                .HasMaxLength(6);

            this.Property(t => t.gw_trnsct_tmk_current_time)
                .HasMaxLength(6);

            this.Property(t => t.gw_trnsct_tmk_TPE_trnsct_TMK_Id)
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tmk_id_tmk_trnsct)
                .HasMaxLength(50);

            this.Property(t => t.gw_trnsct_tmk_status)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("gw_trnsct_tmk");
            this.Property(t => t.gw_trnsct_tmk_id).HasColumnName("gw_trnsct_tmk_id");
            this.Property(t => t.gw_id_merchant).HasColumnName("gw_id_merchant");
            this.Property(t => t.gw_id_magasin).HasColumnName("gw_id_magasin");
            this.Property(t => t.gw_trnsct_tmk_id_terminal).HasColumnName("gw_trnsct_tmk_id_terminal");
            this.Property(t => t.gw_trnsct_tmk_serial_number).HasColumnName("gw_trnsct_tmk_serial_number");
            this.Property(t => t.gw_trnsct_tmk_current_date).HasColumnName("gw_trnsct_tmk_current_date");
            this.Property(t => t.gw_trnsct_tmk_current_time).HasColumnName("gw_trnsct_tmk_current_time");
            this.Property(t => t.gw_trnsct_tmk_TPE_trnsct_TMK_Id).HasColumnName("gw_trnsct_tmk_TPE_trnsct_TMK_Id");
            this.Property(t => t.gw_trnsct_tmk_id_tmk_trnsct).HasColumnName("gw_trnsct_tmk_id_tmk_trnsct");
            this.Property(t => t.gw_trnsct_tmk_result_code).HasColumnName("gw_trnsct_tmk_result_code");
            this.Property(t => t.gw_trnsct_tmk_status).HasColumnName("gw_trnsct_tmk_status");
            this.Property(t => t.gw_trnsct_tmk_confirmation_result_code).HasColumnName("gw_trnsct_tmk_confirmation_result_code");
        }
    }
}
