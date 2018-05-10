using System;
using System.Collections.Generic;

namespace MSS_AspDotNetToAndroid_WebApi_WS.Models
{
    public partial class gw_default_trnsct_type
    {
        public string gw_default_trnsct_type_trnsct_type { get; set; }
        public string gw_default_trnsct_type_default_template_id { get; set; }
        public virtual gw_default_template gw_default_template { get; set; }
    }
}
