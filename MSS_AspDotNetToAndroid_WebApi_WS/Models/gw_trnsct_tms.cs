using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_trnsct_tms
    {
        public string gw_trnsct_tms_id { get; set; }
        public string gw_trnsct_tms_merchant_id { get; set; }
        public string gw_trnsct_tms_magasin_id { get; set; }
        public string gw_trnsct_tms_tpe_id { get; set; }
        public string gw_trnsct_tms_date { get; set; }
        public string gw_trnsct_tms_response { get; set; }
        public string gw_trnsct_tms_tpe_serial_id { get; set; }
        public string gw_trnsct_tms_binary_version_id { get; set; }
        public string gw_trnsct_tms_config_version_id { get; set; }
        public virtual gw_terminal_merchant gw_terminal_merchant { get; set; }
    }
}
