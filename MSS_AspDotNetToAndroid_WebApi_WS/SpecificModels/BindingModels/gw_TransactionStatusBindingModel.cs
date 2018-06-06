using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS_AspDotNetToAndroid_WebApi_WS.SpecificModels.BindingModels
{
    public class gw_TransactionStatusBindingModel
    {
        public string EtatTransaction { get; set; }
        public int NbreTransactionsParEtatTransaction { get; set; }
    }
}