using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_hand_shakeMap : EntityTypeConfiguration<gw_hand_shake>
    {
        public gw_hand_shakeMap()
        {
            // Primary Key
            this.HasKey(t => t.IdHandShake);

            // Properties
            this.Property(t => t.IdHandShake)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IdMerchant)
                .HasMaxLength(50);

            this.Property(t => t.IdMagasin)
                .HasMaxLength(50);

            this.Property(t => t.IdTerminalMerchant)
                .HasMaxLength(50);

            this.Property(t => t.IdTerminal)
                .HasMaxLength(50);

            this.Property(t => t.IMEI)
                .HasMaxLength(50);

            this.Property(t => t.CurrentDate)
                .HasMaxLength(50);

            this.Property(t => t.CurrentTime)
                .HasMaxLength(50);

            this.Property(t => t.ResponseCode)
                .HasMaxLength(50);

            this.Property(t => t.IdHost)
                .HasMaxLength(50);

            this.Property(t => t.HostRoutage)
                .HasMaxLength(50);

            this.Property(t => t.MerchantType)
                .HasMaxLength(50);

            this.Property(t => t.DateSystemTransaction)
                .HasMaxLength(50);

            this.Property(t => t.TimeSystemTransaction)
                .HasMaxLength(50);

            this.Property(t => t.CodeStatus)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_hand_shake");
            this.Property(t => t.IdHandShake).HasColumnName("IdHandShake");
            this.Property(t => t.SentTransaction).HasColumnName("SentTransaction");
            this.Property(t => t.ReceivedTransaction).HasColumnName("ReceivedTransaction");
            this.Property(t => t.IdMerchant).HasColumnName("IdMerchant");
            this.Property(t => t.IdMagasin).HasColumnName("IdMagasin");
            this.Property(t => t.IdTerminalMerchant).HasColumnName("IdTerminalMerchant");
            this.Property(t => t.IdTerminal).HasColumnName("IdTerminal");
            this.Property(t => t.IMEI).HasColumnName("IMEI");
            this.Property(t => t.CurrentDate).HasColumnName("CurrentDate");
            this.Property(t => t.CurrentTime).HasColumnName("CurrentTime");
            this.Property(t => t.ResponseCode).HasColumnName("ResponseCode");
            this.Property(t => t.IdHost).HasColumnName("IdHost");
            this.Property(t => t.HostRoutage).HasColumnName("HostRoutage");
            this.Property(t => t.MerchantType).HasColumnName("MerchantType");
            this.Property(t => t.DateSystemTransaction).HasColumnName("DateSystemTransaction");
            this.Property(t => t.TimeSystemTransaction).HasColumnName("TimeSystemTransaction");
            this.Property(t => t.CodeStatus).HasColumnName("CodeStatus");
        }
    }
}
