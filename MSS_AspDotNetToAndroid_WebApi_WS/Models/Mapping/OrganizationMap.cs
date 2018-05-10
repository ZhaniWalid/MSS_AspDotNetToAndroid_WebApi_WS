using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class OrganizationMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.NumericCode)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.AlphaCode)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Organization");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.OrganismType_Id).HasColumnName("OrganismType_Id");
            this.Property(t => t.Locked).HasColumnName("Locked");
            this.Property(t => t.NumericCode).HasColumnName("NumericCode");
            this.Property(t => t.AlphaCode).HasColumnName("AlphaCode");

            // Relationships
            this.HasOptional(t => t.OrganizationType)
                .WithMany(t => t.Organizations)
                .HasForeignKey(d => d.OrganismType_Id);

        }
    }
}
