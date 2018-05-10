using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class gw_trnsct_GeneralBindingModel
    {
        public string idTransaction { get; set; }
        public string IdMerchant { get; set; } 
        public string IdTerminalMerchant { get; set; } 
        public string IdHost { get; set; }
        public string AmountAuthorisedNumeric { get; set; } 
        public string EtatTransaction { get; set; } 
        public string BankOfRequest { get; set; } 
    }
}