using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class TokenMap : EntityTypeConfiguration<Token>
    {
        public TokenMap()
        {
            // Primary Key
            this.HasKey(t => t.id_token);

            // Properties
            this.Property(t => t.id_token)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fk_id_user)
                .HasMaxLength(128);

            this.Property(t => t.access_token)
                .IsRequired();

            this.Property(t => t.token_type)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.refresh_token)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.error)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Token");
            this.Property(t => t.id_token).HasColumnName("id_token");
            this.Property(t => t.fk_id_user).HasColumnName("fk_id_user");
            this.Property(t => t.access_token).HasColumnName("access_token");
            this.Property(t => t.token_type).HasColumnName("token_type");
            this.Property(t => t.expires_in).HasColumnName("expires_in");
            this.Property(t => t.refresh_token).HasColumnName("refresh_token");
            this.Property(t => t.error).HasColumnName("error");

            // Relationships
            this.HasOptional(t => t.AspNetUser)
                .WithMany(t => t.Tokens)
                .HasForeignKey(d => d.fk_id_user);

        }
    }
}
