using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class gw_trnsct_GeneralBindingModel
    {
        // General Part

        public string idTransaction { get; set; }
        public string IdMerchant { get; set; } 
        public string IdTerminalMerchant { get; set; } 
        public string IdHost { get; set; }
        //public string AmountAuthorisedNumeric { get; set; } 
        public double? Amount { get; set; } // double Amount? =>  Nullable<double> Amount
        public string EtatTransaction { get; set; } 
        public string BankOfRequest { get; set; }
        //
        public string BankId_GateWay { get; set; }
        public string BankName_GateWay { get; set; }
        //

        // Extended Part

        public string EtatCloture { get; set; }
        public string CurrentDate { get; set; }
        public string TimeSystemTransaction { get; set; }
        public string Transactiontype { get; set; }
        public string ResponseCode { get; set; }
        public string FID_F_ApprovalCode { get; set; }
        public string CardMask { get; set; }

        // Another Fields for Ticket Part

        public string ApplicationIdentifierCard { get; set; } // APPID 
        public string ApplicationCryptogram { get; set; } // Sign 
        public string TerminalVerificationResults { get; set; } // TVR 
        public string TransactionStatusInformation { get; set; } // TSI 
        public string CardUsedForPayement { get; set; } // Carte 
        //public string BillingNumber { get; set; } // Num Facturation

        // Code Status pour chercher les transactions réfusé ( rejeté ) ,tq refus (rejet) code = 20
        public string CodeStatus { get; set; }
        public string CodeStatusDescription { get; set; }


    }
}