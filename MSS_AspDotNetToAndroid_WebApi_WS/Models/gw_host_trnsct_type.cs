using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_host_trnsct_type
    {
        public string gw_host_trnsct_type_host_id { get; set; }
        public string gw_host_trnsct_type_trnsct_type { get; set; }
        public string gw_host_trnsct_type_template_id { get; set; }
        public virtual gw_host gw_host { get; set; }
        public virtual gw_template gw_template { get; set; }
    }
}
