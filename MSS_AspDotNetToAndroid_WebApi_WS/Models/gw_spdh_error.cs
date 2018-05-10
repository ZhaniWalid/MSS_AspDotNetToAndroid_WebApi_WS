using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_spdh_error
    {
        public gw_spdh_error()
        {
            this.gw_host_refuse_error = new List<gw_host_refuse_error>();
            this.gw_spdh_trnsct_error = new List<gw_spdh_trnsct_error>();
        }

        public int gw_spdh_error_code { get; set; }
        public string gw_spdh_error_description { get; set; }
        public virtual ICollection<gw_host_refuse_error> gw_host_refuse_error { get; set; }
        public virtual ICollection<gw_spdh_trnsct_error> gw_spdh_trnsct_error { get; set; }
    }
}
