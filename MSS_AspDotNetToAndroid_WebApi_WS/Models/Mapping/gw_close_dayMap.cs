using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models.Mapping
{
    public class gw_close_dayMap : EntityTypeConfiguration<gw_close_day>
    {
        public gw_close_dayMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCloture);

            // Properties
            this.Property(t => t.IdCloture)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IdMerchant)
                .HasMaxLength(50);

            this.Property(t => t.IdMagasin)
                .HasMaxLength(50);

            this.Property(t => t.IdTerminal)
                .HasMaxLength(50);

            this.Property(t => t.SequenceNumber)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.BatchNumber)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.CurrentDate)
                .HasMaxLength(6);

            this.Property(t => t.CurrentTime)
                .HasMaxLength(6);

            this.Property(t => t.ResponseCode)
                .HasMaxLength(3);

            this.Property(t => t.DateSystemCloture)
                .HasMaxLength(6);

            this.Property(t => t.TimeSystemCloture)
                .HasMaxLength(6);

            this.Property(t => t.IMEI)
                .HasMaxLength(50);

            this.Property(t => t.CodeStatus)
                .HasMaxLength(50);

            this.Property(t => t.IdHost)
                .HasMaxLength(50);

            this.Property(t => t.HostRoutage)
                .HasMaxLength(50);

            this.Property(t => t.BankOfRequest)
                .HasMaxLength(50);

            this.Property(t => t.MerchantType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("gw_close_day");
            this.Property(t => t.IdCloture).HasColumnName("IdCloture");
            this.Property(t => t.IdMerchant).HasColumnName("IdMerchant");
            this.Property(t => t.IdMagasin).HasColumnName("IdMagasin");
            this.Property(t => t.IdTerminal).HasColumnName("IdTerminal");
            this.Property(t => t.SequenceNumber).HasColumnName("SequenceNumber");
            this.Property(t => t.BatchNumber).HasColumnName("BatchNumber");
            this.Property(t => t.NumberOfPurchase).HasColumnName("NumberOfPurchase");
            this.Property(t => t.TotalAmountPurchase).HasColumnName("TotalAmountPurchase");
            this.Property(t => t.NumberOfRefund).HasColumnName("NumberOfRefund");
            this.Property(t => t.TotalAmountRefund).HasColumnName("TotalAmountRefund");
            this.Property(t => t.NumberOfPurchaseHost).HasColumnName("NumberOfPurchaseHost");
            this.Property(t => t.TotalAmountPurchaseHost).HasColumnName("TotalAmountPurchaseHost");
            this.Property(t => t.NumberOfRefundHost).HasColumnName("NumberOfRefundHost");
            this.Property(t => t.TotalAmountRefundHost).HasColumnName("TotalAmountRefundHost");
            this.Property(t => t.SentClotureTransaction).HasColumnName("SentClotureTransaction");
            this.Property(t => t.ReceivedClotureTransaction).HasColumnName("ReceivedClotureTransaction");
            this.Property(t => t.CurrentDate).HasColumnName("CurrentDate");
            this.Property(t => t.CurrentTime).HasColumnName("CurrentTime");
            this.Property(t => t.ResponseCode).HasColumnName("ResponseCode");
            this.Property(t => t.DateSystemCloture).HasColumnName("DateSystemCloture");
            this.Property(t => t.TimeSystemCloture).HasColumnName("TimeSystemCloture");
            this.Property(t => t.IMEI).HasColumnName("IMEI");
            this.Property(t => t.CodeStatus).HasColumnName("CodeStatus");
            this.Property(t => t.IdHost).HasColumnName("IdHost");
            this.Property(t => t.HostRoutage).HasColumnName("HostRoutage");
            this.Property(t => t.BankOfRequest).HasColumnName("BankOfRequest");
            this.Property(t => t.MerchantType).HasColumnName("MerchantType");
        }
    }
}
