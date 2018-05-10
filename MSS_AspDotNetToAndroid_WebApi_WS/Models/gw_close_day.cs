using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_close_day
    {
        public gw_close_day()
        {
            this.gw_trnsct = new List<gw_trnsct>();
        }

        public string IdCloture { get; set; }
        public string IdMerchant { get; set; }
        public string IdMagasin { get; set; }
        public string IdTerminal { get; set; }
        public string SequenceNumber { get; set; }
        public string BatchNumber { get; set; }
        public Nullable<int> NumberOfPurchase { get; set; }
        public Nullable<double> TotalAmountPurchase { get; set; }
        public Nullable<int> NumberOfRefund { get; set; }
        public Nullable<double> TotalAmountRefund { get; set; }
        public Nullable<int> NumberOfPurchaseHost { get; set; }
        public Nullable<double> TotalAmountPurchaseHost { get; set; }
        public Nullable<int> NumberOfRefundHost { get; set; }
        public Nullable<double> TotalAmountRefundHost { get; set; }
        public string SentClotureTransaction { get; set; }
        public string ReceivedClotureTransaction { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string ResponseCode { get; set; }
        public string DateSystemCloture { get; set; }
        public string TimeSystemCloture { get; set; }
        public string IMEI { get; set; }
        public string CodeStatus { get; set; }
        public string IdHost { get; set; }
        public string HostRoutage { get; set; }
        public string BankOfRequest { get; set; }
        public string MerchantType { get; set; }
        public virtual ICollection<gw_trnsct> gw_trnsct { get; set; }
    }
}
