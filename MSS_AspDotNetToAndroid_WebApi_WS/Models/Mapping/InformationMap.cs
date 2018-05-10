using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class InformationMap : EntityTypeConfiguration<Information>
    {
        public InformationMap()
        {
            // Primary Key
            this.HasKey(t => t.InformationId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Information");
            this.Property(t => t.InformationId).HasColumnName("InformationId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Organizations)
                .WithMany(t => t.Information)
                .Map(m =>
                    {
                        m.ToTable("OrganizationInformation");
                        m.MapLeftKey("InformationId");
                        m.MapRightKey("OrganizationId");
                    });

            this.HasMany(t => t.Organizations1)
                .WithMany(t => t.Information1)
                .Map(m =>
                    {
                        m.ToTable("OrganizationInformationDefault");
                        m.MapLeftKey("InformationId");
                        m.MapRightKey("OrganizationId");
                    });

            this.HasMany(t => t.Organizations2)
                .WithMany(t => t.Information2)
                .Map(m =>
                    {
                        m.ToTable("OrganizationInformationDefaultDisplay");
                        m.MapLeftKey("InformationId");
                        m.MapRightKey("OrganizationId");
                    });

            this.HasMany(t => t.Organizations3)
                .WithMany(t => t.Information3)
                .Map(m =>
                    {
                        m.ToTable("OrganizationInformationDisplay");
                        m.MapLeftKey("InformationId");
                        m.MapRightKey("OrganizationId");
                    });


        }
    }
}
