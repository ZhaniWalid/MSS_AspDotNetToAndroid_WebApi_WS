using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_trnsct_error
    {
        public string gw_spdh_trnsct_error_trnsct_id { get; set; }
        public string gw_spdh_trnsct_error_field_name { get; set; }
        public int gw_spdh_trnsct_error_error_code { get; set; }
        public string gw_spdh_trnsct_error_request_response { get; set; }
        public virtual gw_spdh_error gw_spdh_error { get; set; }
    }
}
