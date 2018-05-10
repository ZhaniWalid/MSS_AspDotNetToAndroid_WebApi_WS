using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class gw_trnsct_ExtendedBindingModel
    {
        public string idTransaction { get; set; }
        public string EtatCloture { get; set; }
        public string CurrentDate { get; set; }
        public string TimeSystemTransaction { get; set; }
        public string Transactiontype { get; set; }
        public string ResponseCode { get; set; }
        public string FID_F_ApprovalCode { get; set; }
        public string CardMask { get; set; }
    }
}