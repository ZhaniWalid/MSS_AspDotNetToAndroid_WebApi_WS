using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_terminal_bankMap : EntityTypeConfiguration<gw_terminal_bank>
    {
        public gw_terminal_bankMap()
        {
            // Primary Key
            this.HasKey(t => t.gw_terminal_bank_id);

            // Properties
            this.Property(t => t.gw_terminal_bank_id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_bank_bank_id)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_bank_sequence_number)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.gw_terminal_bank_batch_number)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.gw_terminal_bank_status)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_bank_date_status)
                .HasMaxLength(50);

            this.Property(t => t.gw_terminal_bank_trnsct_id)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_terminal_bank");
            this.Property(t => t.gw_terminal_bank_id).HasColumnName("gw_terminal_bank_id");
            this.Property(t => t.gw_terminal_bank_bank_id).HasColumnName("gw_terminal_bank_bank_id");
            this.Property(t => t.gw_terminal_bank_sequence_number).HasColumnName("gw_terminal_bank_sequence_number");
            this.Property(t => t.gw_terminal_bank_batch_number).HasColumnName("gw_terminal_bank_batch_number");
            this.Property(t => t.gw_terminal_bank_status).HasColumnName("gw_terminal_bank_status");
            this.Property(t => t.gw_terminal_bank_date_status).HasColumnName("gw_terminal_bank_date_status");
            this.Property(t => t.gw_terminal_bank_status_occupancy).HasColumnName("gw_terminal_bank_status_occupancy");
            this.Property(t => t.gw_terminal_bank_trnsct_id).HasColumnName("gw_terminal_bank_trnsct_id");

            // Relationships
            this.HasOptional(t => t.gw_bank)
                .WithMany(t => t.gw_terminal_bank)
                .HasForeignKey(d => d.gw_terminal_bank_bank_id);

        }
    }
}
