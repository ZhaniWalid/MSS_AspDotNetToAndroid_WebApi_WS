using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_tpe
    {
        public string gw_tpe_serial_code { get; set; }
        public string gw_tpe_merchant_id { get; set; }
        public string gw_tpe_magasin_id { get; set; }
        public Nullable<int> gw_tpe_availability { get; set; }
        public virtual gw_magasin gw_magasin { get; set; }
        public virtual gw_merchant gw_merchant { get; set; }
    }
}
