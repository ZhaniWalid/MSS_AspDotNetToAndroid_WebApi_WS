using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_user_magasinMap : EntityTypeConfiguration<gw_user_magasin>
    {
        public gw_user_magasinMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_user_magasin_user_id);

            // Properties
            this.Property(t => t.gw_user_magasin_user_id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.gw_user_magasin_magasin_id)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("gw_user_magasin");
            this.Property(t => t.gw_user_magasin_user_id).HasColumnName("gw_user_magasin_user_id");
            this.Property(t => t.gw_user_magasin_magasin_id).HasColumnName("gw_user_magasin_magasin_id");
        }
    }
}
