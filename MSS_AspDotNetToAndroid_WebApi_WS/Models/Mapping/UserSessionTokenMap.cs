using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class UserSessionTokenMap : EntityTypeConfiguration<UserSessionToken>
    {
        public UserSessionTokenMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
           /* this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);*/

            this.Property(t => t.OwnerAspNetUser_fk_Id)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("UserSessionTokens");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OwnerAspNetUser_fk_Id).HasColumnName("OwnerAspNetUser_fk_Id");
            this.Property(t => t.AuthToken).HasColumnName("AuthToken");
            this.Property(t => t.LoginDateTime).HasColumnName("LoginDateTime");
            this.Property(t => t.ExpirationDateTime).HasColumnName("ExpirationDateTime");
            this.Property(t => t.is_LoggedIn_LoggedOut).HasColumnName("is_LoggedIn_LoggedOut");

            // Relationships
             this.HasRequired(t => t.OwnerAspNetUser)
                 .WithMany(t => t.AspNetUserSessionTokens)
                 .HasForeignKey(d => d.OwnerAspNetUser_fk_Id);

            // Relationships
          /*  this.HasOptional(t => t.OwnerAspNetUser) // 'HasOptional' : which means that the you can save 'AspNetUser' data without 'UserSessionToken'.
                .WithRequired(t => t.AspNetUserSessionToken);*/ // 'WithRequired' : which means that you cannot save the 'UserSessionToken' without corresponding 'AspNetUser' Records.


        }
    }
}
