using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class AspNetUserMap : EntityTypeConfiguration<AspNetUser>
    {
        public AspNetUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .HasMaxLength(256);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("AspNetUsers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Organization_Id).HasColumnName("Organization_Id");
            this.Property(t => t.IsFirstConnection).HasColumnName("IsFirstConnection");
            this.Property(t => t.OrganismIdentity_Id).HasColumnName("OrganismIdentity_Id");
            // added by me
            this.Property(t => t.isBlocked).HasColumnName("isBlocked").IsOptional();
            // fin added by me

            // Relationships
            this.HasMany(t => t.AspNetUsers1)
                .WithMany(t => t.AspNetUsers)
                .Map(m =>
                    {
                        m.ToTable("Locked");
                        m.MapLeftKey("LockedId");
                        m.MapRightKey("LockingId");
                    });

            this.HasOptional(t => t.Organization)
                .WithMany(t => t.AspNetUsers)
                .HasForeignKey(d => d.Organization_Id);
            this.HasOptional(t => t.OrganismIdentity)
                .WithMany(t => t.AspNetUsers)
                .HasForeignKey(d => d.OrganismIdentity_Id);
    
        }
    }
}
