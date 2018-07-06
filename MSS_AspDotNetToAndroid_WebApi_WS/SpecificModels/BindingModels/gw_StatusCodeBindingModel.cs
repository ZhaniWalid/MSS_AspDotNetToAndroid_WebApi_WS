using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class gw_StatusCodeBindingModel
    {
        // Code Status pour chercher les transactions réfusé ( rejeté ) ,tq refus (rejet) code = 20
        public string CodeStatus { get; set; }
        public string CodeStatusDescription { get; set; }
        //public int NbreCodeStatus { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        // Newest fields added by me
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public double? Amount { get; set; }
        public string CardOfPayement { get; set; }
        public string BankOfRequest { get; set; }
        public string BankNameGateWay { get; set; }

    }
}