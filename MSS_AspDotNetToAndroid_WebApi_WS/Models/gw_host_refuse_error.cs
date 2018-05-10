using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_host_refuse_error
    {
        public string gw_host_refuse_error_host_id { get; set; }
        public string gw_host_refuse_error_field_name { get; set; }
        public int gw_host_refuse_error_code_error { get; set; }
        public int gw_host_refuse_error_request_response { get; set; }
        public virtual gw_host gw_host { get; set; }
        public virtual gw_spdh_error gw_spdh_error { get; set; }
    }
}
