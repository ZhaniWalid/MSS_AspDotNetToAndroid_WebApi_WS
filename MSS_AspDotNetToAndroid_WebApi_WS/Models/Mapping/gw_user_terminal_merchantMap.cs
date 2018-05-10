using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_user_terminal_merchantMap : EntityTypeConfiguration<gw_user_terminal_merchant>
    {
        public gw_user_terminal_merchantMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_user_terminal_merchant_user_id);

            // Properties
            this.Property(t => t.gw_user_terminal_merchant_user_id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.gw_user_terminal_merchant_terminal_merchant_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_user_terminal_merchant");
            this.Property(t => t.gw_user_terminal_merchant_user_id).HasColumnName("gw_user_terminal_merchant_user_id");
            this.Property(t => t.gw_user_terminal_merchant_terminal_merchant_id).HasColumnName("gw_user_terminal_merchant_terminal_merchant_id");
        }
    }
}
