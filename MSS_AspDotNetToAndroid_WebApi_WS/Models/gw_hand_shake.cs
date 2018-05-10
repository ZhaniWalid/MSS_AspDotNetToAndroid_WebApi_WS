using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_hand_shake
    {
        public string IdHandShake { get; set; }
        public string SentTransaction { get; set; }
        public string ReceivedTransaction { get; set; }
        public string IdMerchant { get; set; }
        public string IdMagasin { get; set; }
        public string IdTerminalMerchant { get; set; }
        public string IdTerminal { get; set; }
        public string IMEI { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string ResponseCode { get; set; }
        public string IdHost { get; set; }
        public string HostRoutage { get; set; }
        public string MerchantType { get; set; }
        public string DateSystemTransaction { get; set; }
        public string TimeSystemTransaction { get; set; }
        public string CodeStatus { get; set; }
    }
}
